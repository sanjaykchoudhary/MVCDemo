using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
   public class CreditCardFactory
    {
        public ICreditCard CreateObject(int cardType)
        {
            ICreditCard product = null;
            if (cardType == 1)
                product = new PlatinumCreditCardFactory().CreateProduct();
            else if (cardType == 2)
                product = new MoneybackCreditCardFactory().CreateProduct();
            else if (cardType == 3)
                product = new TitaniumCreditCardFactory().CreateProduct();

            return product;
        }
    }
}
