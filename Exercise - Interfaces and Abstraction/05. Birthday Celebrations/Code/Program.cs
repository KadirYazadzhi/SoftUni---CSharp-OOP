using System;
using System.Collections.Generic;

namespace BirthdayCelebrations;

public class StartUp {
    private static List<ICitizen> citizens = new List<ICitizen>();
    private static List<IPet> pets = new List<IPet>();

    public static void Main(string[] args) {
        ReadData();
        PrintBirthdays();
    }

    private static void ReadData() {
        string line;
        while ((line = Console.ReadLine()) != "End") {
            string[] data = line.Split(" ");

            if (data[0] == "Citizen") citizens.Add(new Citizen(data[1], int.Parse(data[2]), data[3], data[4]));
            else if (data[0] == "Pet") pets.Add(new Pet(data[1], data[2]));
        }
    }

    private static void PrintBirthdays() {
        string year = Console.ReadLine();

        foreach (var c in citizens) {
            if (c.Birthday.EndsWith(year)) Console.WriteLine(c.Birthday);
        }

        foreach (var p in pets) {
            if (p.Birthday.EndsWith(year)) Console.WriteLine(p.Birthday);
        }
    }
}