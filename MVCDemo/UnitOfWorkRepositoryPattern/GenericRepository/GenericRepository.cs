using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using UnitOfWorkRepositoryPattern.UnitOfWork;
using UnitOfWorkRepositoryPattern.DAL;

namespace UnitOfWorkRepositoryPattern.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private IDbSet<T> _entities;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;
        public GenericRepository(IUnitOfWork<EmployeeDBContext> unitOfWork) : this(unitOfWork.Context)
        {
        }
        public GenericRepository(EmployeeDBContext context)
        {
            _isDisposed = false;
            Context = context;
        }
        public EmployeeDBContext Context { get; set; }
        public virtual IQueryable<T> Table
        {
            get { return Entities; }
        }
        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }
        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public virtual T GetById(object Id)
        {
            return Entities.Find(Id);
        }

        public virtual void Insert(T obj)
        {
            try
            {
                if (obj == null)
                    throw new ArgumentNullException("obj");
                Entities.Add(obj);
                if (Context == null || _isDisposed)
                    Context = new EmployeeDBContext();
                //Context.SaveChanges(); commented out call to savechanges as context save changes will be
                //called with unit of work.
            }
            catch(DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, ex);
            }
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                Context.Configuration.AutoDetectChangesEnabled = false;
                Context.Set<T>().AddRange(entities);
                Context.SaveChanges();
            }
            catch(DbEntityValidationException dbex)
            {
                foreach (var validationErrors in dbex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += string.Format("Property: {0}, Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, dbex);
            }
        }

        public virtual void Update(T obj)
        {
            try
            {
                if (obj == null)
                    throw new ArgumentNullException("obj");
                if (Context == null || _isDisposed)
                    Context = new EmployeeDBContext();
                SetEntryModified(obj);
                //Context.SaveChanges(); commented out call to savechanges as context save changes will be
                //called with unit of work.
            }
            catch (DbEntityValidationException dbex)
            {
                foreach (var validationErrors in dbex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += Environment.NewLine + string.Format("Property: {0}, Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(_errorMessage, dbex);
            }
        }
        public void Delete(T obj)
        {
            try
            { 
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (Context == null || _isDisposed)
                Context = new EmployeeDBContext();
            Entities.Remove(obj);

                //Context.SaveChanges(); commented out call to savechanges as context save changes will be
                //called with unit of work.
            }
            catch(DbEntityValidationException dbex)
            {
                foreach (var validationErrors in dbex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += Environment.NewLine + string.Format("Property: {0},Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(_errorMessage, dbex);
            }
        }
        public virtual void SetEntryModified(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        
    }
}