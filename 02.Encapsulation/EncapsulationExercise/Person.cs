using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public double Money 
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Products.Count > 0)
            {
                sb.AppendLine($"{Name} - {string.Join(", ", Products)}");
            }
            else
            {
                sb.AppendLine($"{Name} - Nothing bought");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
