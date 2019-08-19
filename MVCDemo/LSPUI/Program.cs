using System;
using LSPLibrary;

namespace LSPUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager accountingVP = new Manager();
            accountingVP.FirstName = "Emma";
            accountingVP.LastName = "Stone";
            accountingVP.CalculatePerHourRate(4);

            Employee emp = new Employee();
            emp.FirstName = "Tim";
            emp.LastName = "Corey";
            emp.AssignManager(accountingVP);
            emp.CalculatePerHourRate(2);

            Console.WriteLine($"{emp.FirstName}'s salary is ${emp.Salary} per hour ");
            Console.ReadLine();
        }
    }
}
