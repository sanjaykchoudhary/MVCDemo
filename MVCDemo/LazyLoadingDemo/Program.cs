using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Candidate candidate = new Candidate(1, "John");
            foreach(EducationProfile profile in candidate.GetAllEducationProfile())
            {
                //It will actually load accounts, i.e. Lazy Loading.

                Console.WriteLine("ID: {0}", profile.Id);
                Console.WriteLine("Degree: {0}", profile.Degree);
                Console.Read();
            }
        }
    }
}
