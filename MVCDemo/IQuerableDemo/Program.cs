using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQuerableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new int[] { 5, 10, 20, 24 };
            //we can convert an int array to IQuerable.
            //and then we can pass it to Querable and methods like Average.
            double result = Queryable.Average(values.AsQueryable());
            Console.WriteLine(result);

            /* ----------Another Example------------ */
            //List and Array can be converted to IQuerable.
            List<int> list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int[] array = new int[4];
            array[0] = 4;
            array[0] = 5;
            array[0] = 6;
            array[0] = 7;

            //We can use IQuerable to treat collection as one type.
            Test(list.AsQueryable());
            Test(array.AsQueryable());
            
            Console.ReadLine();
        }

        static void Test(IQueryable<int> items)
        {
            Console.WriteLine($"Average: {items.Average()}");
            Console.WriteLine($"Sum: {items.Sum()}");
        }
    }
}
