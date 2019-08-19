using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWorkRepositoryPattern.DAL;
using UnitOfWorkRepositoryPattern.GenericRepository;
using UnitOfWorkRepositoryPattern.UnitOfWork;

namespace UnitOfWorkRepositoryPattern.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork<EmployeeDBContext> unitOfWork) : base(unitOfWork) { }
        public EmployeeRepository(EmployeeDBContext context) : base(context) { }
        public IEnumerable<Employee> GetEmployeeByGender(string gender)
        {
            return Context.Employees.Where(emp => emp.Gender == gender).ToList();
        }
        public IEnumerable<Employee> GetEmployeeByDepartment(string dept)
        {
            return Context.Employees.Where(emp => emp.Dept == dept).ToList();
        }
    }
}