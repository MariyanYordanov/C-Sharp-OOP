using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(0.4);
            Console.WriteLine(circle.Draw());
            Rectangle rectangle = new Rectangle(1.2,0);
            Console.WriteLine(rectangle.Draw());
        }
    }
}
