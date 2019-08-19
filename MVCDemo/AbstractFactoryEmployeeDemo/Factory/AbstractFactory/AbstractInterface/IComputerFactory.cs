using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractProduct;

namespace AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractInterface
{
   public interface IComputerFactory
    {
        IProcessor Processor();
        IBrand Brand();
        ISystemType SystemType();
    }
}
