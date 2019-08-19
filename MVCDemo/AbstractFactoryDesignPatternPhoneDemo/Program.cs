using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPatternPhoneDemo
{
    /// <summary>
    /// Abstract Factory Pattern Demo.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IMobilePhone nokiaMobilePhone = new Nokia();
            MobileClient nokiaMobileClient = new MobileClient(nokiaMobilePhone);

            Console.WriteLine("*******************NOKIA**************************");
            Console.WriteLine(nokiaMobileClient.GetSmartPhoneModelDetails());
            Console.WriteLine(nokiaMobileClient.GetNormalPhoneModelDetails());

            IMobilePhone samsungMobilePhone = new Samsung();
            MobileClient samsungMobileClient = new MobileClient(samsungMobilePhone);

            Console.WriteLine("******************SAMSUNG******************************");
            Console.WriteLine(samsungMobileClient.GetSmartPhoneModelDetails());
            Console.WriteLine(samsungMobileClient.GetNormalPhoneModelDetails());
            Console.ReadLine();
        }
    }
    ///<summary>
    /// The AbstractFactory interface
    /// </summary>
    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }
    ///<summary>
    ///Concrete class Factory 1 class
    /// </summary>
    class Nokia: IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new NokiaPixel();
        }
        public INormalPhone GetNormalPhone()
        {
            return new Nokia1600();
        }
    }

    class Samsung: IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new SamsungGalaxy();
        }
        public INormalPhone GetNormalPhone()
        {
            return new SamsungGuru();
        }
    }

    ///<summary>
    ///ProductA class - NokiaPixel
    /// </summary>
    class NokiaPixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia Pixel\nRAM: 3GB\nCamera: 8MP\n";
        }
    }
    ///<summary>
    ///ProductA2 class - SamsungGalaxy
    /// </summary>
    class SamsungGalaxy: ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Galaxy\nRAM: 2GB\nCamera: 13MP\n";
        }
    }
    /// <summary>
    /// ProductB1 class - Nokia1600
    /// </summary>
    class Nokia1600 : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia 1600\nRAM: NA\nCamera: NA\n";
        }
    }
    /// <summary>
    /// ProductB2 class- SamsungGuru class
    /// </summary>
    class SamsungGuru: INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Guru\nRAM: NA\nCamera: NA";
        }
    }
    ///<summary>
    ///AbstractProductA interface
    /// </summary>
    interface ISmartPhone
    {
        string GetModelDetails();
    }
    ///<summary>
    ///AbstractProductB interface
    /// </summary>    
    interface INormalPhone
    {
        string GetModelDetails();
    }

}
