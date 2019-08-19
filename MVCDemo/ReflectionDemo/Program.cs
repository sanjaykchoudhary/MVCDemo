using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type type = Type.GetType("ReflectionDemo.Employee");
            //Console.WriteLine(type.FullName);
            //Console.WriteLine(type.Namespace);
            //Console.WriteLine(type.Name);

            //PropertyInfo[] propertyInfo = type.GetProperties();
            //foreach(PropertyInfo info in propertyInfo)
            //{
            //    Console.WriteLine(info.Name);
            //}

            //MethodInfo[] methodInfo = type.GetMethods();
            //foreach(MethodInfo info in methodInfo)
            //{
            //    Console.WriteLine(info.ReturnType.Name);
            //    Console.WriteLine(info.Name);
            //}

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type LType = executingAssembly.GetType("ReflectionDemo.Employee");
            object objEmployee = Activator.CreateInstance(LType);
            MethodInfo method = LType.GetMethod("DisplayEmpName");
            string[] param = new string[1];
            param[0] = "Sanjay Choudhary";
            string employeeName = (string)method.Invoke(objEmployee, param);
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public float Salary { get; set; }

        public Employee()
        {
            this.EmpId = -1;
            this.EmpName = "Sanjay";
            this.Salary = 1000000;
        }

        public Employee(int empid,string name,float salary)
        {
            this.EmpId = empid;
            this.EmpName = EmpName;
            this.Salary = salary;
        }

        public void DisplayName()
        {
            Console.WriteLine("Name: " + this.EmpName);
        }

        public void DisplayEmpName(string name)
        {
            Console.WriteLine("DisplayEmpName Method: " + name);
        }
        public void DisplaySalary()
        {
            Console.WriteLine("Salary: " + this.Salary);
        }
    }
}
