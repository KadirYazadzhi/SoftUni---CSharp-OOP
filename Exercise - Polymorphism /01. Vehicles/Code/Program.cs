using System;
using System.Linq;

namespace Vehicles;

using System;

public class StartUp {
    public static void Main() {
        Dictionary<string, IVehicle> vehiclesMap = new Dictionary<string, IVehicle>();
        
        string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
        vehiclesMap["Car"] = car;

        string[] truckData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));
        vehiclesMap["Truck"] = truck;
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++){
            string command = Console.ReadLine();
            Process(command, vehiclesMap);
        }
        
        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }

    private static void Process(string command, Dictionary<string, IVehicle> vehiclesMap) {
        string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string vehicleType = data[1];
        IVehicle vehicle = vehiclesMap[data[1]];

        if (data[0] == "Drive") {
            double distance = double.Parse(data[2]);

            if (vehicle.Drive(distance)) Console.WriteLine($"{vehicleType} travelled {distance} km");
            else Console.WriteLine($"{vehicleType} needs refueling");
        }
        else if (data[0] == "Refuel") {
            double liters = double.Parse(data[2]);
            vehicle.Refuel(liters);
        }
    }
}

