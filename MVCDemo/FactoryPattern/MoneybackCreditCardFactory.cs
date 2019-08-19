using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class MoneybackCreditCardFactory : CreditCardAbstractFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard moneyback = new MoneybackCreditCard();
            //Do something with this object once you get this object.
            return moneyback;
        }
    }
    public class TitaniumCreditCardFactory : CreditCardAbstractFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard titanium = new TitaniumCreditCard();
            //Do something with the object once you get the object.
            return titanium;
        }
    }
    public class PlatinumCreditCardFactory : CreditCardAbstractFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard platinum = new PlatinumCreditCard();
            //Do something.
            return platinum;
        }
    }
}
