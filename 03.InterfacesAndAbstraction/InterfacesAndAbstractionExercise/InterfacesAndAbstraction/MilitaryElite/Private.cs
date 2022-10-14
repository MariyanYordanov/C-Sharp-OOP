using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            return stringBuilder.ToString().TrimEnd ();
        }

    }
}
