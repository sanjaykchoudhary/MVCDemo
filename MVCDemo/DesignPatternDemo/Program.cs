using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton fromEmployee = new Singleton();
            //fromEmployee.PrintDetails("Hello from Employee");

            //Singleton fromStudents = new Singleton();
            //fromStudents.PrintDetails("Hello from Students");
            //Console.ReadLine();


            //using singleton concept.
            /*Assuming singleton is created from Employee class
             we refer to the GetInstance property from the Singleton class.  */
            Singleton fromEmployee = Singleton.GetInstance;
            fromEmployee.PrintDetails("Hello from Employee");

            /*Assuming singleton is created from Student class
             we refer to the GetInstance property from the Singleton class.  */
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("Hello from Student");

            //This violates the design of singleton pattern.
            Singleton.DerivedClassSingleton derObj = new Singleton.DerivedClassSingleton();
            derObj.PrintDetails("From nested derived class.");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
