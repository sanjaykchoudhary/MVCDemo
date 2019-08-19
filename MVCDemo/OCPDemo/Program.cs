using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPDemo
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    #region Without implemenatation of OCP Principle

    public class Rectangle_W
    {
        public double Height { get; set; }
        public double Width { get; set; }
    }
    public class CombinedAreaCalculator_W
    {
        //This code does exactly what we want it to do, and it works great for rectangles. But, what happens if some of our shapes are circles?
        public double Area(object[] shapes)
        {
            double area = 0;
            foreach(var shape in shapes)
            {
                if(shape is Rectangle_W)
                {
                    Rectangle_W rectangle = (Rectangle_W)shape;
                    area += rectangle.Height * rectangle.Width;
                }
                //We have to change the CombinedAreaCalculator to accommodate this.
                if (shape is Circle_W)
                {
                    Circle_W circle = (Circle_W)shape;
                    area += Math.PI * (circle.Radius) * (circle.Radius);
                }
            }
            return area;
        }
    }

    public class Circle_W
    {
        public double Radius { get; set; }
    }
    //By doing this we have violated the Open/Closed Principle; in order to extend the functionality of the CombinedAreaCalculator class,
    // we had to modify the class's source. What happens when some of our shapes are triangles, or octogons, or trapezoids?
    //In each case, we have to add a new if clause to the CombinedAreaCalculator.
    #endregion
#region //OCP Implementation.
    public abstract class Shape
    {
        public abstract double Area();
    }
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double Area()
        {
            return Height * Width;
        }
    }

    public class Circle: Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
    public class Triangle:Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double Area()
        {
            return Height * Width * 0.5;
        }
    }
    public class CombinedAreaCalculator
    {
        public double Area(Shape[] shapes)
        {
            double area = 0;
            foreach(var shape in shapes)
            {
                area += shape.Area();
            }
            return area;
        }
    }

#endregion
}
