using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCardPattern
{
    public class TitaniumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _cardLimit;
        private int _annualCharge;
        public TitaniumCreditCard(int cardLimit, int annualCharge)
        {
            _cardType = "Titanium Card";
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return "Titanium"; }
        }
        public override int CardLimit
        {
            get { return _cardLimit; }

            set { _cardLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }

            set { _annualCharge = value; }
        }
    }
}
