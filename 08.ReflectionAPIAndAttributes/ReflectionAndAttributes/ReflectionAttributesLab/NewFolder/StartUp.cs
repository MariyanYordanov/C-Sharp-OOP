namespace AuthorProblem
{
    using System;
    
    [Autor("Victor")]
    public class StartUp
    {
        [Autor("George")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
