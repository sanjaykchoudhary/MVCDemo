using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryUsingEFinMVC.DAL;
using RepositoryUsingEFinMVC.Repository;
using System.Data.Entity;

namespace RepositoryUsingEFinMVC.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EmployeeDBContext dbContext;
        private DbSet<T> table = null;
        
        public GenericRepository()
        {
            dbContext = new EmployeeDBContext();
            table = dbContext.Set<T>();            
        }
        public GenericRepository(EmployeeDBContext context)
        {
            dbContext = context;
            table = dbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetByID(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}