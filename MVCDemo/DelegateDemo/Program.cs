using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace DelegateDemo
{
    //Step 1: Create a callback delegate.The actual callback method signature
    //should match with the 
    public delegate void SumOfNumberCallBack(int sum);
    //TutorialTeacher example.
    public delegate void Print(int value);
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("**********************Normal Thread Demo *************************");
            //CallBasicThread();
            //Console.WriteLine("**********************ParameterizedThreadStart Demo *************************");
            //CallParameterizedThread();
            //Console.WriteLine("**********************Pass data to method using ThreadStart delegate Demo *************************");
            //CallPassDataToMethodUsingThreadStartDel_Alternate_TO_ParamThread();
            //Console.WriteLine("**********************Pass data to method and retrieve using callback method using ThreadStart delegate Demo *************************");
            //CallPassDataToMethodAndRetrieveUsingCallBackMethod();
            WriteLine("**********************Normal Delegate Demo from TutorialsTeacher  *************************");
            //Print Delegate points to PrintNumber.
            Print printDel = DelegateBasic.PrintNumber;
            printDel(10000);
            printDel(200);

            //Print Delegate points to PrintMoney
            printDel = new Print(DelegateBasic.PrintMoney);
            printDel(2000);
            printDel(3000);
            //A method can have a parameter of a delegate type and can invoke the delegate parameter.
            DelegateBasic.PrintHelper(DelegateBasic.PrintNumber, 10000);
            DelegateBasic.PrintHelper(DelegateBasic.PrintMoney, 23000);

            WriteLine("**********************Event and Event handler Demo from TutorialsTeacher  *************************");
            PrintHelperSubscriber subscriber = new PrintHelperSubscriber(2000);
            subscriber.PrintMoney();
            subscriber.PrintNumber();

            WriteLine("**********************Event and Event handler with Param Demo from TutorialsTeacher  *************************");
            PrintHelperSubscriberWithParam subs = new PrintHelperSubscriberWithParam(2000);
            subs.PrintMoney();
            subs.PrintHexaDec();
            Test[] array = new Test[1];
            array[0] = new Test();
            array[0].s = "Original";
            Test[] copy = new Test[1];
            array.CopyTo(copy, 0);
            WriteLine("Copy To: " + copy[0].s);
            WriteLine("Array to: " + array[0].s);
            copy[0].s = "Changed";
            WriteLine("Copy To: " + copy[0].s);
            WriteLine("Array to: " + array[0].s);

            Test[] clon = (Test[])array.Clone();
            array[0].s = "Cloned";
            WriteLine("Copy To: " + copy[0].s);
            WriteLine("Array to: " + array[0].s);
            WriteLine("Clone to: " + clon[0].s);

            Console.ReadKey();
        }

        public class Test
        {
            public string s;
        }

        public static void CallBasicThread()
        {
            Number number = new Number();
            Thread t1 = new Thread(number.ComputeNumbers);
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(number.ComputeNumbers));
            t2.Start();
            Thread t3 = new Thread(delegate () { number.ComputeNumbers(); });
            t3.Start();
            Thread t4 = new Thread(() => number.ComputeNumbers());
            t4.Start();
        }
        public static void CallParameterizedThread()
        {
            //Parameterize Thread Demo, where we pass parameter to the thread function.
            Console.WriteLine("Please enter the target number:");
            object target = Console.ReadLine();
            //Create an instance ParameterizedThreadStart delegate.
            ParameterizedThreadStart paramThreadStart = new ParameterizedThreadStart(ParameterizeDelegateEx.PrintNumbers);
            Thread t5 = new Thread(paramThreadStart);
            t5.Start(target);
        }

        public static void CallPassDataToMethodUsingThreadStartDel_Alternate_TO_ParamThread()
        {
            // Prompt the user for the target number
            Console.WriteLine("Please enter the target number");
            // Read from the console and store it in target variable
            int inp = Convert.ToInt32(Console.ReadLine());
            // Create an instance of the ThreadStartDelegateWithData class, passing it
            // the target number that was read from the console
            ThreadStartDelegateWithData data = new ThreadStartDelegateWithData(inp);
            // Specify the Thread function
            Thread t6 = new Thread(new ThreadStart(data.PrintNumbers));
            t6.Start();
        }

        public static void CallPassDataToMethodAndRetrieveUsingCallBackMethod()
        {
            //Prompt the user to enter target number.
            Console.WriteLine("Enter target number:");
            //Read from the console and store it in target variable.
            int targ = Convert.ToInt32(Console.ReadLine());
            //Create an instance of the callback delegate and to its constructor pass the name of the callback function.
            SumOfNumberCallBack sumNumberCallback = new SumOfNumberCallBack(PrintSumOfNumbers);

            //Create the instance of the number class and to it's constructor pass the target number and instance of the callback delegate.
            CallbackDelegateDemoToRetrievData obj = new CallbackDelegateDemoToRetrievData(targ, sumNumberCallback);

            //Create an instance of the thread class and specify the Thread function to invoke.
            Thread t7 = new Thread(new ThreadStart(obj.ComputeSumOfNumbers));
            t7.Start();
        }
        //Callback method that will receive the sum of numbers.
        public static void PrintSumOfNumbers(int sum)
        {
            Console.WriteLine("Sum of numbers using callback method: " + sum);
        }
    }

    class Number
    {
        public void ComputeNumbers()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    class ParameterizeDelegateEx
    {
        public static void PrintNumbers(object target)
        {
            int number = 0;
            if (int.TryParse(target.ToString(), out number))
            {
                for (int i = 0; i <= number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }

    //This class contains the data it needs to print.
    class ThreadStartDelegateWithData
    {
        int _target;
        //when an instance is created, the target number needs to be specified.
        public ThreadStartDelegateWithData(int target)
        {
            //this target number is then stored in the class private variable _target.
            _target = target;
        }
        //Function prints the numbers from 1 to the target number that the user is provided.
        public void PrintNumbers()
        {
            for (int i = 0; i <= _target; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    //Step 2: Create class to compute the sum of numbers and to call the callback method.
    public class CallbackDelegateDemoToRetrievData
    {
        //the target number this class needs to compute the sum of numbers.
        int _target;
        //Delegate to call when the Thread function completes computing the numbers.
        SumOfNumberCallBack _sumOfNumberCallback;
        //callback to initialize the target number and callback delegate.
        public CallbackDelegateDemoToRetrievData(int target, SumOfNumberCallBack delcallback)
        {
            this._target = target;
            this._sumOfNumberCallback = delcallback;
        }

        //This thread function computes the sum of numbers and then invokes the callback method passing it the sum of numbers.
        public void ComputeSumOfNumbers()
        {
            int sum = 0;
            for (int i = 0; i <= _target; i++)
            {
                sum += i;
            }
            if (_sumOfNumberCallback != null)
                _sumOfNumberCallback(sum);
        }
    }    
}
