using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryUsingEFinMVC.DAL;

namespace RepositoryUsingEFinMVC.Repository
{
   public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetByID(int EmpID);
        void Insert(Employee emp);
        void Update(Employee emp);
        void Delete(int empID);
        void Save();
        
    }
}
