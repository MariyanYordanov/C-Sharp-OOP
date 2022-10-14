using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Privates = new List<IPrivate>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            stringBuilder.AppendLine("Privates:");
            foreach (var Private in Privates)
            {
                stringBuilder.AppendLine("  " + Private.ToString());
            }
            
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
