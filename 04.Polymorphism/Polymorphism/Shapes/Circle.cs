namespace Shapes
{
    using System;
    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get => radius;
            private set
            {
                Validator.ValidateValue(value, "radius");
                radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Radius * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
