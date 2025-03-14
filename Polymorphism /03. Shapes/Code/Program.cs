using System;
using System.Linq;

namespace Shapes;

using System;

public class StartUp {
    public static void Main() {
        Shape rectangle = new Rectangle(5, 10);
        Console.WriteLine(rectangle.Draw());
        Console.WriteLine($"Perimeter: {rectangle.CalculatePerimeter()}");
        Console.WriteLine($"Area: {rectangle.CalculateArea()}");

        Shape circle = new Circle(7);
        Console.WriteLine(circle.Draw());
        Console.WriteLine($"Perimeter: {circle.CalculatePerimeter()}");
        Console.WriteLine($"Area: {circle.CalculateArea()}");
    }
}

