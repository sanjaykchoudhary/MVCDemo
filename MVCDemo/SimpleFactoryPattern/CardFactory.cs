using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
   public class CardFactory
    {
        public static ICreditCard GetCardInstance(int cardType)
        {
            ICreditCard cardDetails = null;
            if (cardType == 1)
                cardDetails = new MoneyBackCard();
            else if (cardType == 2)
                cardDetails = new TitaniumCard();
            else if (cardType == 3)
                cardDetails = new PlatinumCard();
            return cardDetails;
        }
    }
}
