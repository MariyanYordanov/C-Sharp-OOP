using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            Circle circle = new Circle(2.12);
            Triangular triangular = new Triangular(3.12, 4.03);
            Square square = new Square(2.13);
            Rectangle rectangle = new Rectangle(1.2, 2.2);

            GraphicEditor.DrawShape(circle);
            GraphicEditor.DrawShape(triangular);
            GraphicEditor.DrawShape(square);
            GraphicEditor.DrawShape(rectangle);
        }
    }
}
