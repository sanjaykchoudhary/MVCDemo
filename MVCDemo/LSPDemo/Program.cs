using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDemo
{
    //states that we should be able to treat a child class as though it were the parent class.
    //Essentially this means that all derived classes should retain the functionality of their parent class and cannot replace any functionality the parent provides.
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Ellipse
    {
        public double MajorAxis { get; set; }
        public double MinorAxis { get; set; }

        public virtual void SetMajorAxis(double majorAxis)
        {
            MajorAxis = majorAxis;
        }
        public virtual void SetMinorAxis(double minorAxis)
        {
            MinorAxis = minorAxis;
        }
        public virtual double Area()
        {
            return Math.PI * MajorAxis * MinorAxis;
        }
    }

    public class Circle : Ellipse
    {
        public override void SetMajorAxis(double majorAxis)
        {
            base.SetMajorAxis(majorAxis);
            this.MinorAxis = majorAxis; //In a Circle, each axis is identical.
        }
    }

}
