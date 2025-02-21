namespace NeedForSpeed;

public class SportCar : Car {
    private double DefaultFuelConsumption { get; set; } = 10;
    
    public SportCar(int horsePower, double fuel) : base(horsePower, fuel) {
        
    }
    
    public override double FuelConsumption => DefaultFuelConsumption;
}