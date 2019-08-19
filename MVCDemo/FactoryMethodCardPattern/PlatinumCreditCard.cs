using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCardPattern
{
   public class PlatinumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _cardLimit;
        private int _annualCharge;
        public PlatinumCreditCard(int cardLimit,int annualCharge)
        {
            _cardType = "Platinum Card";
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return _cardType; }
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
