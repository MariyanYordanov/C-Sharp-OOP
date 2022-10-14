using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;
            Repairs = new List<IRepair>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Corps Corps { get; set; }
        public string PartName { get; set; }
        public int HoursWorked { get; set; }
        public List<IRepair> Repairs { get; set; }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            stringBuilder.AppendLine($"Corps: {Corps}");
            stringBuilder.AppendLine("Repairs:");
            foreach (var Repair in Repairs)
            {
                stringBuilder.AppendLine($"  {Repair.ToString()}");

            }

            return stringBuilder.ToString().TrimEnd();
        }
    }

}
