namespace Vehicles;

public abstract class BaseVehicle : IVehicle {
    public virtual double FuelConsumption { get; }
    public double FuelQuantity { get; private set; }

    protected BaseVehicle(double fuelQuantity, double fuelConsumption) {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public bool Drive(double distance) {
        if (distance < 0) throw new ArgumentException("Distance must be greater than zero");
        
        double necessaryFuel = distance * this.FuelConsumption;
        if (this.FuelQuantity < necessaryFuel) return false;
            
        this.FuelQuantity -= necessaryFuel;
        return true;
    }

    public virtual void Refuel(double liters) {
        if (liters > 0) this.FuelQuantity += liters;
    }
}