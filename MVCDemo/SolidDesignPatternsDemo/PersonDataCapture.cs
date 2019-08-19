using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDesignPatternsDemo
{
  public  class PersonDataCapture
    {
        public static Person Capture()
        {
            Person person = new Person();

            Console.WriteLine("Enter your FirstName:");
            person.FirstName = Console.ReadLine();

            Console.WriteLine("Enter your LastName:");
            person.LastName = Console.ReadLine();

            return person;
        }
    }
}
