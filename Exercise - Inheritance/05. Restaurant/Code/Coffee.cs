namespace Restaurant;

public class Coffee : HotBeverage {
    private const decimal DefaultPrice = 3.5m;
    private const double DefaultMilliliters = 50;
    
    public double Caffeine { get; }
    
    public Coffee(string name, double caffeine) : base(name, DefaultPrice, DefaultMilliliters) {
        this.Caffeine = caffeine;
    }
}