using System;
using System.Collections.Generic;

namespace FoodShortage;

public class StartUp {
    private static Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

    public static void Main(string[] args) {
        ReadData();
        ProcessPurchases();
    }

    private static void ReadData() {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++) {
            string[] data = Console.ReadLine().Split(" ");

            if (data.Length == 4) buyers[data[0]] = new Citizen(data[0], int.Parse(data[1]), data[2], data[3]);
            else if (data.Length == 3) buyers[data[0]] = new Rebel(data[0], int.Parse(data[1]), data[2]);
        }
    }

    private static void ProcessPurchases() {
        string name;
        while ((name = Console.ReadLine()) != "End") {
            if (buyers.ContainsKey(name)) {
                buyers[name].BuyFood();
            }
        }

        int totalFood = 0;
        foreach (var buyer in buyers.Values) {
            totalFood += buyer.Food;
        }

        Console.WriteLine(totalFood);
    }
}