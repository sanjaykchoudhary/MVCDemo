using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardMessages.WelcomeMessage();
            //Ask for user information.

            Person person = PersonDataCapture.Capture();
            bool isPersonValid = PersonValidator.Validate(person);
            if(!isPersonValid)
            {
                StandardMessages.EndApplication();
                return;
            }
            //check to be sure firstName and lastname are valid.

            AccountGenerator.CreateAccount(person);
            StandardMessages.EndApplication();
        }
    }
}
