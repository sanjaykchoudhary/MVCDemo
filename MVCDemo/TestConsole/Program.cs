using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var i = 3;
            //Console.WriteLine("Value of var: ", i);

            Console.WriteLine($"Using expression bodied method:\n{new ExprBodiedMethodnProp().EmployeeDetails()}");
            Console.WriteLine($"Using expression bodied property:\n{new ExprBodiedMethodnProp().EmployeeProp}");
            Console.WriteLine("*************************************Caller Info Demo************************");
            CallerInfoDemo.ShowCallerInfo();
            Console.ReadLine();
        }
    }

    class ExprBodiedMethodnProp
    {
        string FirstName, LastName;
        int empId { get; } = 101;
        string empName { get; } = "Sanjay";
        string empAddress { get; } = "Electornic city, Bangalore-560068";
        double basicSalary { get; } = 1000;
        double empBasicSalary { get; }
        public string FullName => FirstName + " " + LastName;
        
        ///<summary>
        /// Expression bodied method.
        /// </summary>
        public double empHRA() => (basicSalary * 40) / 100;

        ///<summary>
        ///Expression bodied Properties.
        /// </summary>
        public double empHRAProp => (basicSalary * 40) / 100;
        public string EmployeeDetails() => $"EmpId: {empId}\nEmpName: {empName}\nEmp Address: {empAddress}\nEmp HRA: {empHRA()}";

        //Expression bodied property.
        public string EmployeeProp => $"EmpId: {empId}\nEmp Name:{empName}\nEmp Address: {empAddress}\nEmp HRA: {empHRAProp}";

    }

    class CallerInfoDemo
    {
        public static void ShowCallerInfo([CallerMemberName]string callerName=null,[CallerFilePath]string callerFilePath=null,
                                          [CallerLineNumber]int callerLineNum=0)
        {
            Console.WriteLine($"Caller Member Name: {callerName}");
            Console.WriteLine($"Caller File Path: {callerFilePath }");
            Console.WriteLine($"Caller Line Number: {callerLineNum }");
        }
    }
}
