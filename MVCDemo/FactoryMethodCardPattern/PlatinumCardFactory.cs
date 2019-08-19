using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCardPattern
{
    class PlatinumCardFactory : CardFactory
    {
        private int _cardLimit;
        private int _annualCharge;
        public PlatinumCardFactory(int cardLimit,int annualCharge)
        {
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new PlatinumCreditCard(_cardLimit, _annualCharge);
        }
    }
}
