using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCardPattern
{
    /// <summary>
    /// ConcreteCreator class
    /// </summary>
    class MoneybackFactory : CardFactory
    {
        private int _cardLimit;
        private int _annualCharge;
        public MoneybackFactory(int cardLimit,int annualCharge)
        {
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new MoneybackCreditCard(_cardLimit, _annualCharge);
        }
    }
}
