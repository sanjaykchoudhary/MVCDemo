using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractInterface;
using AbstractFactoryEmployeeDemo.Factory.AbstractFactory.AbstractProduct;

namespace AbstractFactoryEmployeeDemo.Factory.AbstractFactory.Client
{
    public class EmployeeSystemManager
    {
        public IComputerFactory _iComputerFactory;
        public EmployeeSystemManager(IComputerFactory computerFactory)
        {
            _iComputerFactory = computerFactory;
        }
        public string GetSystemDetails()
        {
            IBrand brand = _iComputerFactory.Brand();
            IProcessor processor = _iComputerFactory.Processor();
            ISystemType systemType = _iComputerFactory.SystemType();
            string returnValue = string.Format("Computer Configuration: {0},{1},{2}", brand, processor, systemType);
            return returnValue;
        }
    }
}
