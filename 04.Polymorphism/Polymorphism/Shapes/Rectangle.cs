namespace Shapes
{
    using System;
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height;
            private set
            {
                Validator.ValidateValue(value, "height");
                height = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                Validator.ValidateValue(value, "width");
                width = value;
            }
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (height + width);
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
