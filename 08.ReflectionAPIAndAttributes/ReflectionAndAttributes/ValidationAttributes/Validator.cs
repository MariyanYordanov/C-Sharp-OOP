using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any())
                .ToArray();

            foreach (var property in propertyInfos)
            {
                Object value = property.GetValue(obj);
                MyValidationAttribute attr = property.GetCustomAttribute<MyValidationAttribute>();
                bool isValid = attr.IsValid(value);
                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}