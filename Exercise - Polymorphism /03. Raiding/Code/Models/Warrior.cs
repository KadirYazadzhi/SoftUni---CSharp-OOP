namespace Raiding;

public class Warrior : BaseHittingHero {
    private const int DefaultPower = 100;
    
    public Warrior(string name) : base(name, DefaultPower) {
    }
}