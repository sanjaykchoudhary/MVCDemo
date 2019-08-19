using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using UnitOfWorkRepositoryPattern.GenericRepository;

namespace UnitOfWorkRepositoryPattern.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    {
        //Here TContext is nothing but your DBContext class.
        //In our example it is EmployeeDBContext class.
        private readonly TContext _context;
        private bool _isDisposed;
        private string _errorMessage = string.Empty;
        private DbContextTransaction _objTrans;
        private Dictionary<string, object> _repositories;
        //Using the constructor we are initializing the _context variable, that is nothing but
        //we are storing the DBContext(EmployeeDBContext) object in _context variable.
        public UnitOfWork()
        {
            _context = new TContext();
        }
        //The Dispose method is used to free unmanaged resources like files,
        //database connections etc. at any time.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //This context property will return the DBContext object. i.e.(EmployeeDBContext) object.
        public TContext Context { get { return _context; } }
        //This createTransaction method will create a database transaction so that we can do
        //database operation by applying do everything and do nothing principle.
        public void CreateTransaction()
        {
            _objTrans = _context.Database.BeginTransaction();
        }
        //IF all the transaction are done successfully then we need to call this commit()
        //to save the changes permanently in the database.
        public void Commit()
        {
            _objTrans.Commit();
        }
        //IF atleast one of the transaction is failed then we need to call this RollBack()
        //method to Rollback the database changes to its previous state.
        public void Rollback()
        {
            _objTrans.Rollback();
            _objTrans.Dispose();
        }
        //This save method will implement DbContext class SaveChanges method so whenever we do a 
        //transaction we need to call this save() method so that it will make the changes in the database.
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException dbex)
            {
                foreach (var validationErrors in dbex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += string.Format("Property: {0}, Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, dbex);
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
                if (disposing)
                    _context.Dispose();
            _isDisposed = true;
        }
        public GenericRepository<T> GenericRepository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();
            var type = typeof(T).Name;
            if(_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)_repositories[type];
        }
    }
}