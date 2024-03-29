﻿using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                try
                {
                    string[] inputInfo = input.Split(';');
                    if (inputInfo[0] == "Team")
                    {
                        string name = inputInfo[1];
                        Team team = new Team(name);
                        teams.Add(name, team);
                    }
                    else if (inputInfo[0] == "Add")
                    {
                        //"Add;{TeamName};{PlayerName};{Endurance};{Sprint};{Dribble};{Passing};{Shooting}"
                        string teamName = inputInfo[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }

                        string playerName = inputInfo[2];
                        int endurance = int.Parse(inputInfo[3]);
                        int sprint = int.Parse(inputInfo[4]);
                        int dribble = int.Parse(inputInfo[5]);
                        int passing = int.Parse(inputInfo[6]);
                        int shooting = int.Parse(inputInfo[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[teamName].AddPlayer(player);
                    }
                    else if (inputInfo[0] == "Remove")
                    {
                        string teamName = inputInfo[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }

                        string playerName = inputInfo[2];

                        bool removed = teams[teamName].RevomePlayer(playerName);

                        if (!removed)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }
                    }
                    else if (inputInfo[0] == "Rating")
                    {
                        string teamName = inputInfo[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
