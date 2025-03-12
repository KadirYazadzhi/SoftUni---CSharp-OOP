namespace Raiding;

public class DruidFactory : IHeroFactory {
    public IHero Create(string name) => new Druid(name);
}