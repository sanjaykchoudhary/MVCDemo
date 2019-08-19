using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCPLibrary;

namespace OpenClosedSolidPrincipleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IApplicantModel> applicants = new List<IApplicantModel>
            {
                new ManagerModel {FirstName="Tim",LastName="Corey" },
                new PersonModel {FirstName="Sue", LastName="Storm" },
                new PersonModel {FirstName ="Nancy",LastName="Roman" }

                //new PersonModel {FirstName="Tim",LastName="Corey" },
                //new PersonModel {FirstName="Sue", LastName="Storm", TypeOfEmployee=EmployeeType.Manager },
                //new PersonModel {FirstName ="Nancy",LastName="Roman", TypeOfEmployee=EmployeeType.Executive }
            };

            List<EmployeeModel> employees = new List<EmployeeModel>();
            //Account accountProcessor = new Account();
            foreach(var person in applicants)
            {
                employees.Add(person.AccountProcessor.Create(person));
            }
            foreach(var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName}{emp.LastName}:{emp.EmailAddress} IsManager: {emp.IsManager} IsExecutive: {emp.IsExecutive}");
                //Console.WriteLine($"{emp.FirstName}{emp.LastName}:{emp.EmailAddress} IsManager: {emp.IsManager} IsExecutive: {emp.}");
            }
            Console.ReadLine();
        }
    }
}

#region Implemented_Violation of OCP
//static void Main(string[] args)
//{
//    List<PersonModel> applicants = new List<PersonModel>
//            {
//                new PersonModel {FirstName="Tim",LastName="Corey" },
//                new PersonModel {FirstName="Sue", LastName="Storm" },
//                new PersonModel {FirstName ="Nancy",LastName="Roman" }

//                //new PersonModel {FirstName="Tim",LastName="Corey" },
//                //new PersonModel {FirstName="Sue", LastName="Storm", TypeOfEmployee=EmployeeType.Manager },
//                //new PersonModel {FirstName ="Nancy",LastName="Roman", TypeOfEmployee=EmployeeType.Executive }
//            };

//    List<EmployeeModel> employees = new List<EmployeeModel>();
//    Account accountProcessor = new Account();
//    foreach (var person in applicants)
//    {
//        employees.Add(accountProcessor.Create(person));
//    }
//    foreach (var emp in employees)
//    {
//        Console.WriteLine($"{emp.FirstName}{emp.LastName}:{emp.EmailAddress}");
//        //Console.WriteLine($"{emp.FirstName}{emp.LastName}:{emp.EmailAddress} IsManager: {emp.IsManager} IsExecutive: {emp.}");
//    }
//    Console.ReadLine();
//}
#endregion
