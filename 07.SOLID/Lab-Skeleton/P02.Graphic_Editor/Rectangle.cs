namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; }
        public double Height { get; }
        public double Area => Width * Height;

        public string Draw() => $"I'm Recangle";
    }
}
