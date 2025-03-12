namespace Vehicles;

public class Car : BaseVehicle {
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity) {
    }

    protected override double ConsumptionIncrease => 0.9;
}