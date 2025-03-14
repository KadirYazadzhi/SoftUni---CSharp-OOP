namespace Vehicles;

public interface IVehicle {
    double FuelConsumption { get; }
    double FuelQuantity { get; }
    
    bool Drive(double distance);
    void Refuel(double liters);
}