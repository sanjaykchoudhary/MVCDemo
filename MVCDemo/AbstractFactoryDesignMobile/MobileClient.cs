﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignMobile
{
    /// <summary>
    /// The client class.
    /// </summary>
   public class MobileClient
    {
        ISmartPhone smartPhone;
        INormalPhone normalPhone;
        public MobileClient(IMobilePhone factory)
        {
            smartPhone = factory.GetSmartPhone();
            normalPhone = factory.GetNormalPhone();
        }

        public string GetNormalPhoneModelDetails()
        {
            return normalPhone.GetModelDetails();
        }
        public string GetSmartPhoneModelDetails()
        {
            return smartPhone.GetModelDetails();
        }
    }
}
