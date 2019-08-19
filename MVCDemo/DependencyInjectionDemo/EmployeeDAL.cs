using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo
{
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployee();
    }
    public class EmployeeDAL : IEmployeeDAL
    {        
        public List<Employee> SelectAllEmployee()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee() { ID = 1, Name = "Pranaya", Department = "IT" },
                new Employee() { ID = 2, Name = "Kumar", Department = "HR" },
                new Employee() { ID = 3, Name = "Choudhary", Department = "Admin" }
            };
            return employees;
        }
    }
}
