using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CodeNumber = codeNumber;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CodeNumber { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            stringBuilder.AppendLine($"Code Number: {CodeNumber}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
