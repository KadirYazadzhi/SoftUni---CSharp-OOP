namespace Vehicles;

public interface IVehicle {
    double FuelQuantity { get; }
    double FuelConsumption { get; }
    double TankCapacity { get; }
    
    bool Drive(double distance, bool ecoMode);
    bool Refuel(double liters);
}