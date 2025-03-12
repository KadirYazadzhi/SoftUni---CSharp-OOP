namespace Raiding;

public class WarriorFactory : IHeroFactory {
    public IHero Create(string name) => new Warrior(name);
}