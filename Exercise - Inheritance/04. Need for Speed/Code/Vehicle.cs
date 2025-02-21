namespace NeedForSpeed;

public class Vehicle {
    private double DefaultFuelConsumption { get; set; } = 1.25;
    public int HorsePower { get; private set; }
    public double Fuel { get; private set; }
    
    public virtual double FuelConsumption => DefaultFuelConsumption;

    public Vehicle(int horsePower, double fuel) {
        HorsePower = horsePower;
        Fuel = fuel;
    }

    public virtual void Drive(double kilometers) {
       this.Fuel -= this.FuelConsumption * kilometers; 
    }
}