using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor() 
        {
            Type type = typeof(StartUp);

            MethodInfo[] methodInfos = type
                .GetMethods(
                BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.Static);

            foreach (MethodInfo method in methodInfos)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AutorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AutorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }

    }
}
