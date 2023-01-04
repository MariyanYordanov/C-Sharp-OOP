namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type typeClass = Type.GetType(investigatedClass);

            FieldInfo[] fieldInfos = typeClass.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(typeClass, new object[] { });

            stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

            var classField = fieldInfos.Where(f => requestedFields.Contains(f.Name));

            foreach (FieldInfo field in classField)
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type typeClass = Type.GetType(className);

            FieldInfo[] fieldInfos = typeClass
                .GetFields(
                BindingFlags.Instance 
                | BindingFlags.Public 
                | BindingFlags.Static);

            MethodInfo[] methodInfosPublic = typeClass
                .GetMethods(
                BindingFlags.Public 
                | BindingFlags.Instance);

            MethodInfo[] methodInfosNonPublic = typeClass
                .GetMethods(
                BindingFlags.NonPublic 
                | BindingFlags.Instance);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in fieldInfos)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in methodInfosPublic.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }

            foreach (MethodInfo method in methodInfosNonPublic.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methodInfosNonPublic = classType
                .GetMethods(
                BindingFlags.NonPublic
                | BindingFlags.Instance);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methods of Class: {className}");
            stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in methodInfosNonPublic)
            {
                stringBuilder.Append(method.Name);
            }

            return stringBuilder.ToString().Trim();
        }

        public string CollectGetterAndSetters(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methodInfos = classType
                .GetMethods(
                BindingFlags.Public 
                | BindingFlags.NonPublic
                | BindingFlags.Static 
                | BindingFlags.Instance);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (MethodInfo method in methodInfos)
            {
                if (method.Name.StartsWith("get"))
                {
                    stringBuilder.AppendLine(
                        $"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    stringBuilder.AppendLine(
                        $"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
