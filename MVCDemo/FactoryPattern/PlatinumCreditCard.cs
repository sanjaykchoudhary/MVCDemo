using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class PlatinumCreditCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 2000;
        }

        public int GetCardLimit()
        {
            return 40000;
        }

        public string GetCardType()
        {
            return "Platinum Card";
        }
    }
}
