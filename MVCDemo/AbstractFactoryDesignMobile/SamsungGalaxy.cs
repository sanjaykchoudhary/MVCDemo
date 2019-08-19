using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignMobile
{
    /// <summary>
    /// The 'Product A2' class
    /// </summary>
    class SamsungGalaxy : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Samsung Galaxy";
        }
    }
}
