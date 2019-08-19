using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
   public class Scooter:IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Driving Scooter: " + miles.ToString() + " km");
        }
    }
}
