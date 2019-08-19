using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo
{
   public class EmployeeBAL
    {
        IEmployeeDAL employeeDAL;
        //public EmployeeBAL(IEmployeeDAL _employeeDAL)
        //{
        //    this.employeeDAL = _employeeDAL;
        //}
        public IEmployeeDAL EmployeeDataObject
        {
            set
            {
                this.employeeDAL = value;
            }
            get
            {
                if(EmployeeDataObject == null)
                {
                    throw new Exception("Employee is not initialized");
                }
                else
                {
                    return this.employeeDAL;
                }
            }
        }
        public List<Employee> GetAllEmployee()
        {
            return employeeDAL.SelectAllEmployee();
        }

        public List<Employee> GetAllEmployee(IEmployeeDAL _employeeDAL)
        {
            employeeDAL = _employeeDAL;
            return employeeDAL.SelectAllEmployee();
        }
    }
}
