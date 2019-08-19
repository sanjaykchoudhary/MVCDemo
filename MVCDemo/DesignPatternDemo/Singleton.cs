using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDemo
{
    public class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    return instance = new Singleton();
                return instance;
            }
        }
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter value: " + counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

        //Nested class: to avoid the constructor protection level, we have nested the class.
        //To show why we need sealed keyword after having private constructor.
        //here this class is responsible for creating or invoking the private constructor, which
        //internally incremented the counter value. This has violated the singleton pattern and 
        //created multiple objects.
        public class DerivedClassSingleton : Singleton
        {

        }
    }
}
