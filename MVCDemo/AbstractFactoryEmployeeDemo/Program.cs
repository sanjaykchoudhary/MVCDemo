using System;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractInterface;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.Client;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.ConcreteFactory;

namespace AbstractFactoryEmployeeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the employee object.
            Employee employee = new Employee()
            {
                Name = "Sanjay",
                JobDescription = "IT Professional",
                Department = "IT",
                EmployeeTypeID = 1
            };

            //Create the abstract factory object.
            IComputerFactory factory = new EmployeeSystemFactory().Create(employee);

            //use the abstract factory object while creating the client and then
            //get the system details.
            EmployeeSystemManager manager = new EmployeeSystemManager(factory);
            employee.ComputerDetails = manager.GetSystemDetails();

            //store the employee into the database.
            using (DesignPatternDBContext context = new DesignPatternDBContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            Console.WriteLine("Employee inserted successfully.");
            Console.ReadKey();
        }
    }
}
