namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public Square(double side)
        {
            Side = side;
        }

        public double Side { get; }
        public double Area => Side * Side;

        public string Draw() => $"I'm Square";
    }
}
