﻿using System;
using System.Collections.Generic;

namespace PersonsInfo {
    public class StartUp {
        public static void Main() {
            int lines = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < lines; i++) {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try {
                    Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                    persons.Add(person);
                } 
                catch (ArgumentException ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            Team team = new Team("SoftUni");

            foreach (Person person in persons) {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}