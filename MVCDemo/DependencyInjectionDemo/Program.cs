using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Constructor dependency injection.
            //EmployeeBAL employeeBAL = new EmployeeBAL(new EmployeeDAL());

            //Property dependency injection. means dependency object is injected thru class property in client.
            EmployeeBAL employeeBAL = new EmployeeBAL();
            employeeBAL.EmployeeDataObject = new EmployeeDAL();
            List<Employee> employees = employeeBAL.GetAllEmployee();
            foreach(Employee emp in employees)
            {
                Console.WriteLine("ID = {0}\tName = {1}\tDepartment = {2}\n", emp.ID, emp.Name, emp.Department);
            }
            List<Employee> ListEmployee = employeeBAL.GetAllEmployee(new EmployeeDAL());
            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine("ID = {0}\tName = {1}\tDepartment = {2}\n", emp.ID, emp.Name, emp.Department);
            }
            Console.ReadKey();
        }
    }
}
