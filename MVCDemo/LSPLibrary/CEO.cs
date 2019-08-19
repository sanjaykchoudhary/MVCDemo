using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPLibrary
{
    public class CEO : BaseEmployee, IManager
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 150M;
            Salary = baseAmount * rank;
        }
        
        public void GeneratePerformanceReview()
        {
            //Simulate reviewing a direct report.
            Console.WriteLine("I'm reviewing a direct report's performace.");
        }
        public void FireSomeOne()
        {
            //Simulate firing someone.
            Console.WriteLine("You are fired.");
        }

        //implemented when we inherited Employee class and it was violating LSP
        //public override void AssignManager(Employee manager)
        //{
        //    throw new InvalidOperationException("The CEO has no manager");
        //}
    }
}
