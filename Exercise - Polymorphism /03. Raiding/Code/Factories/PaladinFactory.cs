namespace Raiding;

public class PaladinFactory : IHeroFactory {
    public IHero Create(string name) => new Paladin(name);
}