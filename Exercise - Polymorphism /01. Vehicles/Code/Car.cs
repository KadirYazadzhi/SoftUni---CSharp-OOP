namespace Vehicles;

public class Car : BaseVehicle {
    public Car(double fuelQuantity, double fuelConsumption)  : base(fuelQuantity, fuelConsumption) {
        
    }
    
    public override double FuelConsumption => base.FuelConsumption + 0.9;
}