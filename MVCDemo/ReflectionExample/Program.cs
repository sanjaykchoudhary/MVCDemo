using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionExample
{
   public class Program
    {
        static void Main(string[] args)
        {
            //Teacher_Interview ti = new Teacher_Interview()
            //{
            //    UID = 101,
            //    Name = "Sanjay",
            //    Email = "sanjay@gmail.com",
            //    Subject = "IT"
            //};

            //Teacher_College tc = new Teacher_College()
            //{
            //    TID = ti.UID,
            //    Name = ti.Name,
            //    Email = ti.Email
            //};

            //var records=(ti).MapProperties<>

            ReflectionTest.Height = 100; //Set Value
            ReflectionTest.Width = 50; //Set Value
            ReflectionTest.Weight = 100; //Set Value
            ReflectionTest.Name = "Sanjay"; //Set Value
            ReflectionTest.Write(); //Invoke reflection method.

            //Load the current executing assembly as the customer class is present in it.
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            //Load the Customer class for which we want to create an instance dynamically.
            Type customerType = executingAssembly.GetType("ReflectionExample.Customer");
            //Create the instance of the customer type using Activator class.
            object objEmployee = Activator.CreateInstance(customerType);
            //Get the method information using the customerType and GetMethod().
            MethodInfo methodInfo = customerType.GetMethod("GetFullName");
            string[] parameters= new string[2];
            parameters[0] = "Sanjay";
            parameters[1] = "Choudhary";
            //Invoke the method passing in customerInstance and parameters array.
            string fullName = (string)methodInfo.Invoke(objEmployee, parameters);

            Console.WriteLine("FullName: {0}", fullName);
            Console.ReadLine();
        }

        
    }

    public class Customer
    {
        public string GetFullName(string firstName,string LastName)
        {
            return firstName + " " + LastName;
        }
    }

    public class Teacher_Interview
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
    }

    public class Teacher_College
    {
        public int TID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public static class MyExtension
    {
        public static void MatchAndMap<TSource, TDestination>(this TSource source, TDestination destination) where TSource : class, new()
            where TDestination : class, new()
        {
            if (source != null && destination != null)
            {
                List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
                List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();
                foreach (PropertyInfo sourceProperty in sourceProperties)
                {
                    PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);
                    if (destinationProperty != null)
                    {
                        try
                        {
                            destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                        }
                        catch (Exception ex) { }
                    }
                }
            }
        }

        public static TDestination MapProperties<TDestination>(this object source) where TDestination :  class, new()
        {
            var destination = Activator.CreateInstance<TDestination>();
            MatchAndMap(source, destination);
            return destination;
        }
    }

    public class ReflectionTest
    {
        public static int Height;
        public static int Width;
        public static int Weight;
        public static string Name;

        public static void Write()
        {
            Type type = typeof(ReflectionTest);
            FieldInfo[] fields = type.GetFields();//obtain all fields.
            foreach(var field in fields) //loop through fields.
            {
                string name = field.Name; //get string name
                object temp = field.GetValue(null); //Get value.
                if(temp is int) //see if it is int.
                {
                    int value = (int)temp;
                    Console.WriteLine(name);
                    Console.WriteLine(" (int) = ");
                    Console.WriteLine(value);
                }
                else if(temp is string) //if it is string.
                {
                    string value = temp as string;
                    Console.WriteLine(name);
                    Console.WriteLine(" (String) = ");
                    Console.WriteLine(value);
                }
                        
            }
        }
    }
}
