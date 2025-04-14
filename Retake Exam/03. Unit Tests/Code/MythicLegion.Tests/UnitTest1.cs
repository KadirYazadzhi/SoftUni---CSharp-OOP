using System;
using NUnit.Framework;
using System.Linq;

namespace MythicLegion.Tests
{
    public class Tests
    {
        private Legion legion;
        private Hero hero1;
        private Hero hero2;

        [SetUp]
        public void Setup()
        {
            legion = new Legion();
            hero1 = new Hero("Arthur", "Knight");
            hero2 = new Hero("Merlin", "Wizard");
        }

        [Test]
        public void Constructor_ShouldInitializeEmptyHeroList()
        {
            Assert.That(legion.GetLegionInfo(), Is.EqualTo("No heroes in the legion."));
        }

        [Test]
        public void AddHero_WithValidHero_ShouldAddHeroSuccessfully()
        {
            legion.AddHero(hero1);
            Assert.That(legion.GetLegionInfo(), Does.Contain("Arthur"));
        }

        [Test]
        public void AddHero_WithNullHero_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => legion.AddHero(null));
        }

        [Test]
        public void AddHero_WithDuplicateName_ShouldThrowArgumentException()
        {
            legion.AddHero(hero1);
            var duplicateHero = new Hero("Arthur", "Warrior");
            Assert.Throws<ArgumentException>(() => legion.AddHero(duplicateHero));
        }

        [Test]
        public void RemoveHero_WithExistingHero_ShouldReturnTrueAndRemoveHero()
        {
            legion.AddHero(hero1);
            var result = legion.RemoveHero("Arthur");
            Assert.That(result, Is.True);
            Assert.That(legion.GetLegionInfo(), Is.EqualTo("No heroes in the legion."));
        }

        [Test]
        public void RemoveHero_WithNonExistingHero_ShouldReturnFalse()
        {
            var result = legion.RemoveHero("NonExistent");
            Assert.That(result, Is.False);
        }

        [Test]
        public void TrainHero_WithExistingHero_ShouldUpdateHeroStats()
        {
            legion.AddHero(hero1);
            var result = legion.TrainHero("Arthur");
            
            Assert.That(result, Is.EqualTo("Arthur has been trained."));
            Assert.That(hero1.Health, Is.EqualTo(101));
            Assert.That(hero1.Power, Is.EqualTo(30));
            Assert.That(hero1.IsTrained, Is.True);
        }

        [Test]
        public void TrainHero_WithNonExistingHero_ShouldReturnNotFoundMessage()
        {
            var result = legion.TrainHero("NonExistent");
            Assert.That(result, Is.EqualTo("Hero with name NonExistent not found."));
        }

        [Test]
        public void GetLegionInfo_WithMultipleHeroes_ShouldReturnCorrectFormat()
        {
            legion.AddHero(hero1);
            legion.AddHero(hero2);
            var info = legion.GetLegionInfo();
            
            Assert.That(info, Does.Contain("Arthur (Knight)"));
            Assert.That(info, Does.Contain("Merlin (Wizard)"));
            Assert.That(info, Does.Contain("Power: 20"));
            Assert.That(info, Does.Contain("Health: 100"));
            Assert.That(info, Does.Contain("Trained: False"));
        }

        [Test]
        public void GetLegionInfo_WithEmptyLegion_ShouldReturnEmptyMessage()
        {
            var info = legion.GetLegionInfo();
            Assert.That(info, Is.EqualTo("No heroes in the legion."));
        }

        [Test]
        public void AddHero_WithMultipleHeroes_ShouldMaintainOrder()
        {
            legion.AddHero(hero1);
            legion.AddHero(hero2);
            var info = legion.GetLegionInfo();
            
            var lines = info.Split(Environment.NewLine);
            Assert.That(lines[0], Does.Contain("Arthur"));
            Assert.That(lines[1], Does.Contain("Merlin"));
        }
    }
}