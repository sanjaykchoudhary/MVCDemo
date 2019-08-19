using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCardPattern
{
    /// <summary>
    /// The creator abstract class.
    /// </summary>
   abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
}
