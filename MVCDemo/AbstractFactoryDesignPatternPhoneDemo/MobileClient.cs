using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPatternPhoneDemo
{
    /// <summary>
    /// Mobile Client class
    /// </summary>
    class MobileClient
    {
        ISmartPhone smartPhone;
        INormalPhone normalPhone;
        public MobileClient(IMobilePhone factory)
        {
            smartPhone = factory.GetSmartPhone();
            normalPhone = factory.GetNormalPhone();
        }

        public string GetSmartPhoneModelDetails()
        {
            return smartPhone.GetModelDetails();
        }
        public string GetNormalPhoneModelDetails()
        {
            return normalPhone.GetModelDetails();
        }

    }
}
