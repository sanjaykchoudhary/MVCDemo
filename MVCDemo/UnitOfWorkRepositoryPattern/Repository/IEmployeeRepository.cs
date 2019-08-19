using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPattern.DAL;
using UnitOfWorkRepositoryPattern.GenericRepository;

namespace UnitOfWorkRepositoryPattern.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeeByGender(string gender);
        IEnumerable<Employee> GetEmployeeByDepartment(string dept);
    }
}
