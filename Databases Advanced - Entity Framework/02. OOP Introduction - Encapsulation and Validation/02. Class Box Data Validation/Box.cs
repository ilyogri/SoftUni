using System;

namespace _02.Class_Box_Data_Validation
{
    public class Box
    {
        private double length;
        private double height;
        private double width;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    return;
                }
                this.length = value;
            }
        }

        public double Width {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    return;
                }
                this.width = value;
            }
        }
        public double Height {
            get { return this.height; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    return;
                }
                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
        public double CalculateLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
        public double CalculateVolume()
        {
            return  this.Length * this.Width * this.Height;
        }
    }
}