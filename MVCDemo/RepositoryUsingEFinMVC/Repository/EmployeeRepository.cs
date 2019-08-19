using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryUsingEFinMVC.DAL;

namespace RepositoryUsingEFinMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeRepository()
        {
            _dbContext = new DAL.EmployeeDBContext();
        }
        public EmployeeRepository(EmployeeDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetByID(int EmpID)
        {
            return _dbContext.Employees.Find(EmpID);
        }
        public void Insert(Employee emp)
        {
            _dbContext.Employees.Add(emp);
        }

        public void Update(Employee emp)
        {
            _dbContext.Entry(emp).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int empID)
        {
            Employee emp = _dbContext.Employees.Find(empID);
            _dbContext.Employees.Remove(emp);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }       
    }
}