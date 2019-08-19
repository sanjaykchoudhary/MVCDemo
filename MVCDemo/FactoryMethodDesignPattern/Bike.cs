using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
   public class Bike: IFactory
    {
        public void Drive(int miles)
        {
            Console.Write("Drive the Bike:" + miles.ToString() + "km");
        }
    }
}
