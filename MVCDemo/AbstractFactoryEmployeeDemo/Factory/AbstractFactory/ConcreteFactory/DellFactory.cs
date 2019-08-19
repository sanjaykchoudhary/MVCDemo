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
    public class DellFactory : IComputerFactory
    {
        public IBrand Brand()
        {
            return new Dell();
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

    public class DellLaptopFactory : DellFactory
    {
        public override ISystemType SystemType()
        {
            return new Laptop();
        }
    }
}
