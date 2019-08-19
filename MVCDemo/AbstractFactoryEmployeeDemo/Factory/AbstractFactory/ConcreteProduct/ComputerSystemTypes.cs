using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractProduct;

namespace AbstractFactoryEmployeeDemo.Factory.AbstractFactory.ConcreteProduct
{
   public class Laptop : ISystemType
    {
        public string GetSystemTypes()
        {
            return Enum.ComputerTypes.Laptop.ToString();
        }
    }
    public class Desktop : ISystemType
    {
        public string GetSystemTypes()
        {
            return Enum.ComputerTypes.Desktop.ToString();
        }
    }
}
