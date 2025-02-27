namespace AnimalFarm.Models;
public class Chicken {
    public const int MinAge = 0;
    public const int MaxAge = 15;

    private string name;
    private int age;

    public Chicken(string name, int age) {
        try {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");

            if (age < MinAge || age > MaxAge) throw new ArgumentException("Age should be between 0 and 15.");

            this.name = name;
            this.age = age;
        }
        catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
            Environment.Exit(1);
        }
    }

    public string Name => this.name;
    public int Age => this.age;

    public double ProductPerDay => this.CalculateProductPerDay();

    private double CalculateProductPerDay() {
        return this.age switch {
            >= 0 and <= 3 => 1.5,
            >= 4 and <= 7 => 2,
            >= 8 and <= 11 => 1,
            _ => 0.75
        };
    }
}
