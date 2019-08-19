using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(() => PrintTeacherDetails(),
                            () => PrintStudentDetails());
            Console.ReadKey();
        }

        private static void PrintTeacherDetails()
        {
            Singleton fromTeacher = Singleton.GetInstance;
            fromTeacher.PrintDetails("From Teacher object is getting created.");
        }
        private static void PrintStudentDetails()
        {
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student object is getting created.");
        }
    }

    public sealed class Singleton
    {
        //private static readonly object instanceLock = new object();
        private static int Counter = 0;
        //private static Singleton instance = null;
        private static readonly Lazy<Singleton> instanceLock = new Lazy<Singleton>(() => new Singleton());

        public static Singleton GetInstance
        {
            //get
            //{
            //    if (instance == null)
            //    {
            //        lock (instanceLock)
            //        {
            //            if (instance == null)
            //                instance = new Singleton();
            //        }
            //    }
            //    return instance;
            //}
            //With Lazy Loading implementation.
            get
            {
                return instanceLock.Value;
            }
        }
        private Singleton()
        {
            Counter++;
            Console.WriteLine("Counter value: " + Counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
