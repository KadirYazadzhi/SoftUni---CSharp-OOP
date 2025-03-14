namespace Vehicles;

public class Truck : BaseVehicle {
    public Truck(double fuelQuantity, double fuelConsumption)  : base(fuelQuantity, fuelConsumption) {
        
    }
    
    public override double FuelConsumption => base.FuelConsumption + 1.6;

    public override void Refuel(double liters) => base.Refuel(liters * 0.95);
    
}