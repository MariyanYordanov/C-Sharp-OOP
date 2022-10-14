using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, IPrivate> privates = new Dictionary<int, IPrivate>(); 
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split();
                string type = data[0];
                int id = int.Parse(data[1]);
                string firstName = data[2];
                string lastName = data[3];
                if (type == "Private")
                {
                    decimal salary = decimal.Parse(data[4]);
                    IPrivate @private = new Private(id, firstName, lastName, salary);
                    if (!privates.ContainsKey(id))
                    {
                        privates.Add(id, @private);
                    }

                    Console.WriteLine(@private.ToString());
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(data[4]);
                    ILieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < data.Length; i++)
                    {
                        int privateId = int.Parse(data[i]);
                        IPrivate @private = privates[privateId];
                        lieutenant.Privates.Add(@private);
                    }

                    Console.WriteLine(lieutenant.ToString());
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corpsString = data[5];
                    bool isValidEnum = Enum.TryParse(corpsString, out Corps corps);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string repairPart = data[i];
                        int repairHours = int.Parse(data[i + 1]);
                        IRepair repair = new Repair(repairPart, repairHours);
                        engineer.Repairs.Add(repair);
                    }

                    Console.WriteLine(engineer.ToString());
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corpsString = data[5];
                    bool isValidEnum = Enum.TryParse(corpsString, out Corps corps);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string missionCodeName = data[i];
                        string missionState = data[i + 1];

                        bool isValidMission = Enum.TryParse(missionState, out State state);
                        if (!isValidMission)
                        {
                            continue;
                        }

                        IMission mission = new Mission(missionCodeName, state);
                        commando.Missions.Add(mission);
                    }

                    Console.WriteLine(commando.ToString());
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(data[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    Console.WriteLine(spy.ToString());
                }

                input = Console.ReadLine();
            }
            
        }
    }
}
