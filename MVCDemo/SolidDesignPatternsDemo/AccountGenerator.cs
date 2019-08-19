using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDesignPatternsDemo
{
   public class AccountGenerator
    {
        public static void CreateAccount(Person person)
        {
            //create username for the person.
            Console.WriteLine($"Your username is {person.FirstName.Substring(0, 1)}{person.LastName}");
        }
    }
}
