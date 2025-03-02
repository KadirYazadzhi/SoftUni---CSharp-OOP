namespace BirthdayCelebrations;

public class Citizen : ICitizen {
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthday { get; }

    public Citizen(string name, int age, string id, string birthday) {
        Name = name;
        Age = age;
        Id = id;
        Birthday = birthday;
    }
}