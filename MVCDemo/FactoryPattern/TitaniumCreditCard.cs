using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class TitaniumCreditCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 1000;
        }

        public int GetCardLimit()
        {
            return 30000;
        }

        public string GetCardType()
        {
            return "Titanium Card";
        }
    }
}
