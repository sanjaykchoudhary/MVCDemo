using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is going to return an instance of a particular card type object
            //through the interface IcreditCard.
            ICreditCard creditCardInstance = new PlatinumCreditCardFactory().CreateProduct();
            if(creditCardInstance != null)
            {
                Console.WriteLine("Card Type: " + creditCardInstance.GetCardType());
                Console.WriteLine("Card Limit: " + creditCardInstance.GetCardLimit());
                Console.WriteLine("Annual Charge: " + creditCardInstance.GetAnnualCharge());
            }
            else
            {
                Console.WriteLine("Invalid Card type.");
            }
            Console.WriteLine("*************************************************************");
            creditCardInstance = new MoneybackCreditCardFactory().CreateProduct();
            if(creditCardInstance !=null)
            {
                Console.WriteLine("Card Type: " + creditCardInstance.GetCardType());
                Console.WriteLine("Card Limit: " + creditCardInstance.GetCardLimit());
                Console.WriteLine("Annual Charge: " + creditCardInstance.GetAnnualCharge());
            }
            else
            {
                Console.WriteLine("Invalid Card type.");
            }

            Console.WriteLine("******************************Credit Card Factory Layer is another abstract layer*******************************");
            //This is going to return an instance of a Particular Card type object 
            int cardType = Convert.ToInt32(Console.ReadLine());
            ICreditCard cardFactory = new CreditCardFactory().CreateObject(cardType);
            if (creditCardInstance != null)
            {
                Console.WriteLine("Card Type: " + cardFactory.GetCardType());
                Console.WriteLine("Card Limit: " + cardFactory.GetCardLimit());
                Console.WriteLine("Annual Charge: " + cardFactory.GetAnnualCharge());
            }
            else
            {
                Console.WriteLine("Invalid Card type.");
            }
            Console.ReadLine();
        }
    }
}
