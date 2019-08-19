using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class MoneybackCreditCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 500;
        }

        public int GetCardLimit()
        {
            return 20000;
        }

        public string GetCardType()
        {
            return "MoneyBack Card";
        }
    }
}
