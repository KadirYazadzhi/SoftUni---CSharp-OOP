using System;
using System.Collections.Generic;
using LegendsOfValor_TheGuildTrials.Models.Contracts;

namespace Models
{
    public class Guild : IGuild
    {
        private string name;
        private readonly List<string> legion;

        public Guild(string name)
        {
            Name = name;
            Wealth = 5000;
            legion = new List<string>();
            IsFallen = false;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value != "WarriorGuild" && value != "SorcererGuild" && value != "ShadowGuild")
                {
                    throw new ArgumentException("Unknown guilds hold no place in this realm.");
                }
                name = value;
            }
        }

        public int Wealth { get; private set; }

        public IReadOnlyCollection<string> Legion => legion.AsReadOnly();

        public bool IsFallen { get; private set; }

        public void RecruitHero(IHero hero)
        {
            if (IsFallen)
            {
                return;
            }

            Wealth -= 500;
            legion.Add(hero.RuneMark);
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            if (IsFallen)
            {
                return;
            }

            Wealth -= 200 * heroesToTrain.Count;
        }

        public void WinWar(int goldAmount)
        {
            if (IsFallen)
            {
                return;
            }

            Wealth += goldAmount;
        }

        public void LoseWar()
        {
            IsFallen = true;
            Wealth = 0;
        }
    }
} 