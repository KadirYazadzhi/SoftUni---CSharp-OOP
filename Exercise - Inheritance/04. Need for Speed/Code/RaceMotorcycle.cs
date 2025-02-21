namespace NeedForSpeed;

public class RaceMotorcycle : Motorcycle {
    private double DefaultFuelConsumption { get; set; } = 8;
    
    public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel) {
        
    }
    
    public override double FuelConsumption => DefaultFuelConsumption;
}