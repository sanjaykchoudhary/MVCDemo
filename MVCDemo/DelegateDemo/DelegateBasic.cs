using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class DelegateBasic
    {
        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }

        public static void PrintHelper(Print delegateFunc, int numToPrint)
        {
            delegateFunc(numToPrint);
        }
    }

    public class PrintHelper
    {
        //Declare delegate.
        public delegate void BeforePrint();

        //Declare event of type delegate.
        public event BeforePrint beforePrintEvent;

        public PrintHelper() { }

        public void PrintNumber(int num)
        {
            //Call delegate method before going to print.
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Number: {0, -12:N0}", num);
        }

        public void PrintDecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Decimal: {0:G}", dec);
        }

        public void PrintMoney(int money)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();
            Console.WriteLine("Money: {0:C}", money);
        }
        public void PrintTemperature(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }

        public void PrintHexadecimal(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Number in Hex: {0:X}", num);
        }

    }

    public class PrintHelperSubscriber
    {
        private PrintHelper _printHelper;

        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public PrintHelperSubscriber(int val)
        {
            Value = val;
            _printHelper = new PrintHelper();
            //subscribe to beforePrintEvent event.
            _printHelper.beforePrintEvent += _printHelper_beforePrintEvent;
        }

        //BeforePrintEvent helper.
        private void _printHelper_beforePrintEvent()
        {
            Console.WriteLine("BeforePrintEvent Handler: PrintHelper event is going to print a value.");
        }
        public void PrintMoney()
        {
            _printHelper.PrintMoney(_value);
        }
        public void PrintNumber()
        {
            _printHelper.PrintNumber(_value);
        }
    }

    public class PrintHelperPublisher
    {
        //declare delegate which accept value as a string.
        public delegate void BeforePrint(string message);
        //declare event of type delegate.
        public event BeforePrint beforePrintEvent;

        public void PrintNumber(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("Print Number");

            Console.WriteLine("Number: {0,-12:N0}", num);
        }
        public void PrintDecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("Print Decimal");

            Console.WriteLine("Decimal: {0:G}", dec);
        }
        public void PrintMoney(int money)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("Print Money");
            Console.WriteLine("Money: {0:C}", money);
        }
        public void PrintTemperature(int temp)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("Print Temp");
            Console.WriteLine("Temp: {0,4:N1}", temp);
        }

        public void PrintHexa(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent("Print Hexa");
            Console.WriteLine("Hexa: {0:X}", num);
        }
    }

    public class PrintHelperSubscriberWithParam
    {
        public PrintHelperPublisher _printHelper;
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public PrintHelperSubscriberWithParam(int val)
        {
            _value = val;
            _printHelper = new DelegateDemo.PrintHelperPublisher();
            _printHelper.beforePrintEvent += _printHelper_beforePrintEvent;
        }

        private void _printHelper_beforePrintEvent(string message)
        {
            Console.WriteLine("Print helper before Print event: BeforePrintEvent fires from {0}", message);
        }

        public void PrintMoney()
        {
            _printHelper.PrintMoney(_value);
        }

        public void PrintHexaDec()
        {
            _printHelper.PrintHexa(_value);
        }
    }
}
