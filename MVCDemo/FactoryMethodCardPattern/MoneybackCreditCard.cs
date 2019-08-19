using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCardPattern
{
  public  class MoneybackCreditCard: CreditCard
    {
        private readonly string _cardType;
        private int _cardLimit;
        private int _annualCharge;

        public MoneybackCreditCard(int cardLimit, int annualCharge)
        {
            _cardType = "Moneyback card";
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return _cardType; }
        }
        public override int CardLimit
        {
            get { return 40000; }

            set { _cardLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return 1000; }

            set { _annualCharge = value; }
        }
    }
}
