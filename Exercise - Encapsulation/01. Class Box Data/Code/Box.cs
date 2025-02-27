namespace BoxData;

public class Box {
    public double Length { get; }
    public double Width { get; }
    public double Height { get; }
    
    public Box(double length, double width, double height) {
        try {
            if (length <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            if (width <= 0) throw new ArgumentException("Width cannot be zero or negative.");
            if (height <= 0) throw new ArgumentException("Height cannot be zero or negative.");

            Length = length;
            Width = width;
            Height = height;
        }
        catch (ArgumentException ex) {
            Console.WriteLine($"{ex.Message}");
            Environment.Exit(1);
        }
    }

    public double SurfaceArea() => (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
    
    public double LateralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);

    public double Volume() => Length * Width * Height;
}