namespace ShoppingSpree;

class Person {
    public string Name { get; }
    public decimal Money { get; private set; }
    public List<Product> Bag { get; }

    public Person(string name, decimal money) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
        if (money < 0) throw new ArgumentException("Money cannot be negative");

        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public bool BuyProduct(Product product) {
        if (Money >= product.Cost) {
            Money -= product.Cost;
            Bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
            return true;
        }
        else {
            Console.WriteLine($"{Name} can't afford {product.Name}");
            return false;
        }
    }
}

