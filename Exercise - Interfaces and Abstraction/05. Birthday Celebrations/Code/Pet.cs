namespace BirthdayCelebrations;

public class Pet : IPet {
    public string Name { get; }
    public string Birthday { get; }

    public Pet(string name, string birthday) {
        Name = name;
        Birthday = birthday;
    }
}