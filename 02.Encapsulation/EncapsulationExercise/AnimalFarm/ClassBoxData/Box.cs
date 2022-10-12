using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get => this.length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double result = 
                (2 * this.Length * this.Width) + 
                (2 * this.Length * this.Height) + 
                (2 * this.Width * this.Height);
            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            return result;
        }

        public double Volume()
        {
            double result = this.Length * this.Width * this.Height;
            return result;
        }
    }
}
