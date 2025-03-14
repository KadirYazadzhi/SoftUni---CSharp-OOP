namespace Animals;

public class Animal {
    public string Name { get; set; }
    public string FavoriteFood { get; set; }

    public Animal(string name, string favoriteFood) {
        Name = name;
        FavoriteFood = favoriteFood;
    }

    public virtual string ExplainSelf() {
        return $"I am {this.Name} and my favourite food is {this.FavoriteFood}";
    }
}