﻿namespace PersonsInfo;

using System;

public class StartUp {
    public static void Main() {
        int lines = int.Parse(Console.ReadLine());

        List<Person> persons = new List<Person>();
        
        for (int i = 0; i < lines; i++){
            string[] cmdArgs = Console.ReadLine().Split();

            Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));

            persons.Add(person);
        }

        decimal parcentage = decimal.Parse(Console.ReadLine());

        persons.ForEach(p => p.IncreaseSalary(parcentage));

        persons.ForEach(p => Console.WriteLine(p.ToString())); 
    }
}
