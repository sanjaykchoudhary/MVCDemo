using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractProduct;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractInterface;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.ConcreteProduct;

namespace AbstractFactoryEmployeeDemo.Factory.AbstractFactory.ConcreteFactory
{
    //implement the abstract factory interface IComputerFactory to create
    //concrete product for Apple Laptop and Desktop.
    public class AppleFactory : IComputerFactory
    {
        public IBrand Brand()
        {
            return new Apple();
        }

        public IProcessor Processor()
        {
            return new I7();
        }

        public virtual ISystemType SystemType()
        {
            return new Desktop();
        }
    }

    //As for Laptop and Desktop, the Brand and processor remains the same
    //so lets implement the MACFactory to create the MACLaptopFactory product
    //and here we need to override the SystemType function.
    public class AppleLaptopFactory : AppleFactory
    {
        public override ISystemType SystemType()
        {
            return new Laptop();
        }
    }
}
