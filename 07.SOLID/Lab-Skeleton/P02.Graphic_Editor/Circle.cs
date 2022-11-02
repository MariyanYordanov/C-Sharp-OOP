using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        private readonly double Pi = 3.1428; 
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }
        public double Area => Radius * Radius * Pi;

        public string Draw() => $"I'm Circle";
    }
}
