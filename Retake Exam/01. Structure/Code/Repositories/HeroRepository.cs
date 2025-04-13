using System;
using System.Collections.Generic;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public void AddModel(IHero hero)
        {
            heroes.Add(hero);
        }

        public IHero GetModel(string runeMark)
        {
            return heroes.Find(h => h.RuneMark == runeMark);
        }

        public IReadOnlyCollection<IHero> GetAll()
        {
            return heroes.AsReadOnly();
        }
    }
} 