namespace _01.Class_Box
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

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