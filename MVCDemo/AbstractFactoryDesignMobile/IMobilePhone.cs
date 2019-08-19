using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignMobile
{
    /// <summary>
    /// The AbstractFactory interface.
    /// </summary>
   public interface IMobilePhone
    {
        INormalPhone GetNormalPhone();
        ISmartPhone GetSmartPhone();
    }
}
