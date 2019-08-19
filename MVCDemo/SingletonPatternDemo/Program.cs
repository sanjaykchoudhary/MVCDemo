using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    ////Bad code. No Thread safe. don't use.
    //public sealed class Singleton
    //{
    //    //Private construction.
    //    private Singleton() { }
    //    private static Singleton instance = null;
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //                instance = new Singleton();
    //            return instance;
    //        }
    //    }
    //}

    public sealed class Singleton
    {
        //Explicit static constructor to tell C# compiler
        //not to mark type as before field init.
        
        private Singleton() { }

        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>
            (() => new Singleton());
        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }    
            
        }
    }
}
