namespace Shapes;

public class Circle : Shape {
    private double radius;

    public Circle(double radius) {
        this.Radius = radius;
    }

    public double Radius {
        get => radius;
        private set {
            if (value <= 0) throw new ArgumentException("Radius must be positive.");
            radius = value;
        }
    }

    public override double CalculatePerimeter() => 2 * Math.PI * Radius;
    
    public override double CalculateArea() => Math.PI * Radius * Radius;
    
}