using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractProduct;

namespace AbstractFactoryEmployeeDemo.Factory.AbstractFactory.ConcreteProduct
{
    public class Apple : IBrand
    {
        public string GetBrand()
        {
            return Enum.Brands.APPLE.ToString();
        }
    }
    public class Dell : IBrand
    {
        public string GetBrand()
        {
            return Enum.Brands.DELL.ToString();
        }
    }
}
