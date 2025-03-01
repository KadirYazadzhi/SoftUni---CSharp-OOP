using System;
using System.Text.RegularExpressions;

namespace BorderControl;

public class StartUp {
    private static List<Robot> robots = new List<Robot>();
    private static List<Citizen> citizens = new List<Citizen>();
    private static List<string> allEntries = new List<string>();  

    public static void Main(string[] args) {
        ReadData();
        CheckForFakeIds();
    }

    private static void ReadData() {
        string line = String.Empty;
        while ((line = Console.ReadLine()) != "End") {
            string[] data = line.Split(" ");

            if (data.Length == 2) {
                robots.Add(new Robot(data[0], data[1]));
                allEntries.Add(data[1]);  
            }
            else {
                citizens.Add(new Citizen(data[0], int.Parse(data[1]), data[2]));
                allEntries.Add(data[2]); 
            }
        }
    }

    private static void CheckForFakeIds() {
        int num = int.Parse(Console.ReadLine());

        List<string> fakeIds = new List<string>();

        foreach (var entry in allEntries){
            if (entry.EndsWith(num.ToString())) fakeIds.Add(entry);
        }

        foreach (var fakeId in fakeIds) {
            Console.WriteLine(fakeId);
        }
    }
}