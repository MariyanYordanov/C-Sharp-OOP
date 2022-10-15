namespace Shapes
{
    using System;
    public static class Validator
    {
        public static  void ValidateValue(double value, string valueName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"The {valueName} can't be negative or zero.");
            }
        }
    }
}
