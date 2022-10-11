using System;
using System.Text;

namespace Animals
{
    public class Animals
    {
        private string name;

        private int age;

        private string gender;

        public Animals(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (char.IsDigit(value[0]) == true)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value == "Male" || value == "Female")
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.GetType().Name);
            stringBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            stringBuilder.AppendLine(this.ProduceSound());

            return stringBuilder.ToString().TrimEnd();
        }
    }
}