namespace Shapes;

public class Rectangle : Shape {
    private double height;
    private double width;

    public Rectangle(double height, double width) {
        this.Height = height;
        this.Width = width;
    }

    public double Height {
        get => height;
        private set {
            if (value <= 0) throw new ArgumentException("Height must be positive.");
            height = value;
        }
    }

    public double Width {
        get => width;
        private set {
            if (value <= 0) throw new ArgumentException("Width must be positive.");
            width = value;
        }
    }

    public override double CalculatePerimeter() => 2 * (Height + Width);
    
    public override double CalculateArea() => Height * Width;
    
}

