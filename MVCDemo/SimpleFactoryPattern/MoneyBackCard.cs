using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    public class MoneyBackCard : ICreditCard
    {
        public string GetCardType()
        {
            return "Money back";
        }
        public int GetCreditLimit()
        {
            return 10000;
        }
        public int GetAnnualCharge()
        {
            return 500;
        }
    }
    public class TitaniumCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 1000;
        }

        public string GetCardType()
        {
            return "Titanium Card";
        }

        public int GetCreditLimit()
        {
            return 20000;
        }
    }
    public class PlatinumCard : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 2000;
        }

        public string GetCardType()
        {
            return "Platinum Card";
        }

        public int GetCreditLimit()
        {
            return 40000;
        }
    }
}
