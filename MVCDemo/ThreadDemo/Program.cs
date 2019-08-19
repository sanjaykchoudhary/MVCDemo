using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static object locker = new object();
        private static int counter;
        
        static void Main(string[] args)
        {
            //This example demonstrates the Race condition.

            //Thread thread1 = new Thread(PrintStar);
            //thread1.Start();

            //Thread t2 = new Thread(PrintPlus);
            //t2.Start();

            //Task.Factory.StartNew(PrintPlus);
            //Task.Factory.StartNew(PrintStar);

            //Synchronization using Thread.Join()
            //var T1 = new Thread(PrintStar);
            //T1.Start();
            //T1.Join();

            //var T2 = new Thread(PrintPlus);
            //T2.Start();
            //T2.Join();

            ////Synchronization with Task.ContinueWith.
            //Task T1 = Task.Factory.StartNew(PrintPlus);
            //Task T2 = T1.ContinueWith(antacedent => PrintStar());
            //Task.WaitAll(new Task[] { T1, T2 });

            //Synchronization using Lock.
            Thread T1 = new Thread(PrintPlus);
            T1.Start();
            Thread T2 = new Thread(PrintStar);
            T2.Start();

            //main Thread will always execute after T1 and T2 completes its execution.
            Console.WriteLine("Ending Main Thread.");
            Console.ReadLine();

        }

        //Synchronization using Monitor Enter-Monitor Exit.
        static void PrintStar()
        {
            Monitor.Enter(locker);//Thread Safe.
            try
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" * " + "\t");
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }

        }
        static void PrintPlus()
        {
            Monitor.Enter(locker);//Thread safe.
            try
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" + " + "\t");
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }

        }

        //static void PrintStar()
        //{
        //    lock(locker)//Thread Safe.
        //    {
        //        for (counter = 0; counter < 5; counter++)
        //        {
        //            Console.WriteLine("*" + "\t");
        //        }
        //    }

        //}
        //private static void PrintPlus()
        //{
        //    lock(locker)//Thread safe.
        //    {
        //        for (counter = 0; counter < 5; counter++)
        //        {
        //            Console.WriteLine("+" + "\t");
        //        }
        //    }

        //}


        //static void PrintStar()
        //{
        //    for (counter = 0; counter < 5; counter++)
        //    {
        //        Console.WriteLine("*" + "\t");
        //    }
        //}
        //private static void PrintPlus()
        //{
        //    for (counter = 0; counter < 5; counter++)
        //    {
        //        Console.WriteLine("+" + "\t");
        //    }
        //}
    }
}
