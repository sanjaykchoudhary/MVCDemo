using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int cardType = Convert.ToInt32(Console.ReadLine());
            ICreditCard cardDetails = CardFactory.GetCardInstance(cardType);
            if(cardDetails !=null)
            {
                Console.WriteLine("Card Type: " + cardDetails.GetCardType());
                Console.WriteLine("Card Limit: " + cardDetails.GetCreditLimit());
                Console.WriteLine("Card Annual Charge: " + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.WriteLine("Invalid Card Type.");
            }
            Console.ReadLine();
        }
    }
}
