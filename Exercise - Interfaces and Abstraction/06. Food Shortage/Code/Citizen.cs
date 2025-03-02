namespace FoodShortage;

public class Citizen : ICitizen, IBuyer {
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthday { get; }
    public int Food { get; set; }

    public Citizen(string name, int age, string id, string birthday) {
        Name = name;
        Age = age;
        Id = id;
        Birthday = birthday;
        Food = 0;
    }

    public void BuyFood() {
       this.Food += 10; 
    }
}