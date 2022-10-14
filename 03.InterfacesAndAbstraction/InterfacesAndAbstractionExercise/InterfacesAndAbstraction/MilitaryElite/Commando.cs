using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Commando : ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;
            Missions = new List<IMission>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Corps Corps { get; set; }
        public List<IMission> Missions { get; set; }

        public void CompleteMission(string codeName)
        {
            IMission mission = Missions.FirstOrDefault(x => x.CodeName == codeName);
            mission.State = State.Finished;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            stringBuilder.AppendLine($"Corps: {Corps}");
            stringBuilder.AppendLine($"Missions:");
            foreach (var Mission in Missions)
            {
                stringBuilder.AppendLine("  " + Mission.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
