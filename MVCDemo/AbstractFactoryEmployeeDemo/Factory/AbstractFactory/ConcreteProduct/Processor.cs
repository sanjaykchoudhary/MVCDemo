using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractProduct;

namespace AbstractFactoryEmployeeDemo.Factory.AbstractFactory.ConcreteProduct
{
    public class I7 : IProcessor
    {
        public string GetProcessor()
        {
            return Enum.Processors.I7.ToString();
        }
    }
    public class I5 : IProcessor
    {
        public string GetProcessor()
        {
            return Enum.Processors.I5.ToString();
        }
    }
    public class I3: IProcessor
    {
        public string GetProcessor()
        {
            return Enum.Processors.I3.ToString();
        }
    }
}
