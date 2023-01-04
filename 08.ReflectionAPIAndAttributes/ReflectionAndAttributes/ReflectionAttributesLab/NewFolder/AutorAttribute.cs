namespace AuthorProblem
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = true)]
    public class AutorAttribute : Attribute
    {
        public AutorAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
