using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignMobile
{
    /// <summary>
    /// The 'Product A1' class.
    /// </summary>
   public class NokiaPixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Nokia Pixel";
        }
    }
}
