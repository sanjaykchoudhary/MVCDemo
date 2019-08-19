using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = 10; //int
            object b = new Customer(); //customer object.
            object c = new Product(); //product object.
            object d = "John"; //String
            object e = new { Name = "Sanjay", Class = "High" }; //Anonymous type.
            object g = a;

            object f = "Some text";
            string text = f.ToString();

            var ah = 10; // int
            var bi = 10d; // double
            var cd = "text"; // string
            var ps = new Product(); // Product type  

            dynamic amount = 100;
            amount = amount + 200;
            Console.WriteLine("Here is the type amount: {0}", amount.GetType());
            amount = "Hundred";
            Console.WriteLine("Here is the type amount: {0}", amount.GetType());


            //dynamic myObj = SomeMethod();
            //myObj.DoSomething();
            //myObj.Method1();

        }
        //public void CheckVar()
        //{
        //    var test = 10;         // after this line test has become of integer type
        //    test = test + 10;    // No error
        //    test = "hello";        // Compile time error as test is an integer type
        //}

        public void CheckDynamic()
        {
            dynamic test = 10;
            test = test + 10;    // No error
            test = "hello";       // No error, neither compile time nor run time
        }
        

    }
}
