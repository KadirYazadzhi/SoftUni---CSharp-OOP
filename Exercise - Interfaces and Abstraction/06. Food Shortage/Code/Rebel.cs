namespace FoodShortage;

public class Rebel : IRebel, IBuyer {
    public string Name { get; }
    public int Age { get; }
    public string Group { get; }  
    public int Food { get; set; }

    public Rebel(string name, int age, string group) {
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
    }

    public void BuyFood() {
        this.Food += 5;
    }
}