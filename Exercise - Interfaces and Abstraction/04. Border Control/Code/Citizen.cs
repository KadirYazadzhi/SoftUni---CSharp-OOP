namespace BorderControl;

public class Citizen : ICitizen {
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }

    public Citizen(string name, int age, string id) {
        Name = name;
        Age = age;
        Id = id;
    }
}