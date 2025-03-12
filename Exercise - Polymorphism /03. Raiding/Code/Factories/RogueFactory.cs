namespace Raiding;

public class RogueFactory : IHeroFactory {
    public IHero Create(string name) => new Rogue(name);
}