namespace Animals;

public abstract class Animal {
    public string Name { get; }
    public int Age { get; }
    public string Gender { get; }

    protected Animal(string name, int age, string gender) {
        if (string.IsNullOrWhiteSpace(name) || age < 0 || string.IsNullOrWhiteSpace(gender))
            throw new ArgumentException("Invalid input!");

        Name = name;
        Age = age;
        Gender = gender;
    }

    public abstract string ProduceSound();

    public override string ToString() => $"{GetType().Name}\n{Name} {Age} {Gender}\n{ProduceSound()}";
}