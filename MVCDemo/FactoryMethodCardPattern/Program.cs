using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCardPattern
{
    /// <summary>
    /// Factory pattern demo.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CardFactory factory = null;
            Console.WriteLine("Enter the card type you would like to visit: ");
            string card = Console.ReadLine();
            switch(card.ToLower())
            {
                case "moneyback":
                    factory = new MoneybackFactory(50000, 0);
                    break;
                case "titanium":
                    factory = new TitaniumCreditcardFactory(100000, 500);
                    break;
                case "platinum":
                    factory = new PlatinumCardFactory(200000, 1000);
                    break;
                default:
                    break;
            }
            CreditCard creditCard = factory.GetCreditCard();
            Console.WriteLine("Your card details are as below: \n");
            Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}", creditCard.CardType, creditCard.CardLimit, creditCard.AnnualCharge);
            Console.ReadKey();
        }
    }
}
