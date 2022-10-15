namespace Vehicles
{
    using System;
    public static class Validator
    {
        public static void ValidateValue(double value)
        {
            if (value <= 0)
            {
                throw new System.Exception("Invalid value");
            }
        }

    }
}