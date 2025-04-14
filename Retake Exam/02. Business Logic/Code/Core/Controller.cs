using System;
using System.Collections.Generic;
using System.Linq;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Core.Contracts;
using Models;
using Repositories;

namespace Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IGuild> guilds;

        public Controller()
        {
            heroes = new HeroRepository();
            guilds = new GuildRepository();
        }

        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != "Warrior" && heroTypeName != "Sorcerer" && heroTypeName != "Spellblade")
            {
                return $"The winds whisper no knowledge of a {heroTypeName}.";
            }

            if (heroes.GetModel(runeMark) != null)
            {
                return $"A hero bearing the RuneMark {runeMark} already walks among us.";
            }

            IHero hero = heroTypeName switch
            {
                "Warrior" => new Warrior(heroName, runeMark),
                "Sorcerer" => new Sorcerer(heroName, runeMark),
                "Spellblade" => new Spellblade(heroName, runeMark),
                _ => throw new ArgumentException($"Invalid hero type: {heroTypeName}")
            };

            heroes.AddModel(hero);
            return $"{heroTypeName} {heroName} awakened with RuneMark {runeMark}.";
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetModel(guildName) != null)
            {
                return $"The banners of {guildName} already fly high in the realm.";
            }

            var guild = new Guild(guildName);
            guilds.AddModel(guild);
            return $"Guild {guildName} has been founded with 5000 gold.";
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            var hero = heroes.GetModel(runeMark);
            if (hero == null)
            {
                return $"No hero bearing the RuneMark {runeMark} walks this realm.";
            }

            var guild = guilds.GetModel(guildName);
            if (guild == null)
            {
                return $"No guild known as {guildName} has been founded.";
            }

            if (!string.IsNullOrEmpty(hero.GuildName))
            {
                return $"Hero {hero.Name} has already sworn loyalty to a guild.";
            }

            if (guild.IsFallen)
            {
                return $"The {guildName} lies in ruin and cannot accept new champions.";
            }

            if (guild.Wealth < 500)
            {
                return $"The coffers of the {guildName} run dry — recruitment is impossible.";
            }

            bool isCompatible = hero switch
            {
                Warrior w => guildName == "WarriorGuild" || guildName == "ShadowGuild",
                Sorcerer s => guildName == "SorcererGuild" || guildName == "ShadowGuild",
                Spellblade sb => guildName == "WarriorGuild" || guildName == "SorcererGuild",
                _ => false
            };

            if (!isCompatible)
            {
                string heroType = hero.GetType().Name;
                return $"The path of the {heroType} does not align with the {guildName}.";
            }

            hero.JoinGuild(guild);
            guild.RecruitHero(hero);
            return $"Hero {hero.Name} has joined the {guildName}.";
        }

        public string TrainingDay(string guildName)
        {
            var guild = guilds.GetModel(guildName);
            if (guild == null)
            {
                return $"No guild known as {guildName} has been founded.";
            }

            if (guild.IsFallen)
            {
                return $"The fallen {guildName} can no longer rally its legion.";
            }

            int totalTrainingCost = 200 * guild.Legion.Count;
            if (guild.Wealth < totalTrainingCost)
            {
                return $"The coffers of the {guildName} cannot bear the weight of this training day.";
            }

            var heroesToTrain = guild.Legion
                .Select(runeMark => heroes.GetModel(runeMark))
                .Where(hero => hero != null)
                .ToList();

            guild.TrainLegion(heroesToTrain);
            return $"{guildName} has completed training for {heroesToTrain.Count} heroes – costing {totalTrainingCost} gold.";
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            var attacker = guilds.GetModel(attackerGuildName);
            var defender = guilds.GetModel(defenderGuildName);

            if (attacker == null || defender == null)
            {
                return "The clash cannot commence — one or more guilds are yet to be founded.";
            }

            if (attacker.IsFallen || defender.IsFallen)
            {
                return "The clash cannot commence — one or more guilds have fallen.";
            }

            int attackerStrength = CalculateGuildStrength(attacker);
            int defenderStrength = CalculateGuildStrength(defender);

            if (attackerStrength > defenderStrength)
            {
                int goldAmount = defender.Wealth;
                attacker.WinWar(goldAmount);
                defender.LoseWar();
                return $"War won! {attackerGuildName} has vanquished {defenderGuildName} and claimed {goldAmount} gold.";
            }
            else
            {
                int goldAmount = attacker.Wealth;
                defender.WinWar(goldAmount);
                attacker.LoseWar();
                return $"War lost! {defenderGuildName} has defended valiantly and claimed {goldAmount} gold from {attackerGuildName}.";
            }
        }

        public string ValorState()
        {
            var guildsList = guilds.GetAll()
                .OrderByDescending(g => g.Wealth)
                .ToList();

            var result = new List<string> { "Valor State:" };

            foreach (var guild in guildsList)
            {
                result.Add($"{guild.Name} (Wealth: {guild.Wealth})");

                var guildHeroes = guild.Legion
                    .Select(runeMark => heroes.GetModel(runeMark))
                    .Where(hero => hero != null)
                    .OrderBy(hero => hero.Name)
                    .ToList();

                foreach (var hero in guildHeroes)
                {
                    result.Add($"-{hero}");
                    result.Add($"--{hero.Essence()}");
                }
            }

            return string.Join("\r\n", result);
        }

        private int CalculateGuildStrength(IGuild guild)
        {
            return guild.Legion
                .Select(runeMark => heroes.GetModel(runeMark))
                .Where(hero => hero != null)
                .Sum(hero => hero.Power + hero.Mana + hero.Stamina);
        }
    }
} 