namespace P02.Graphic_Editor
{
    public static class GraphicEditor 
    {
        public static void DrawShape(IShape shape)
        {
            System.Console.WriteLine(shape.Draw());
        }
       
    }
}
