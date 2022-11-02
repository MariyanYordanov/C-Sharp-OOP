namespace P02.Graphic_Editor
{
    public class Triangular : IShape
    {
        public Triangular(double height, double side)
        {
            Height = height;
            Side = side;
        }

        public double Height { get; }
        public double Side { get; }
        public double Area => Side * Height;

        public string Draw() => $"I'm a Triangular";
    }
}
