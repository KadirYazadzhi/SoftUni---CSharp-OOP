﻿using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models.AnimalTypes {
    public abstract class Feline : Mammal, IFeline {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion) {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append($"{this.Breed}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]");
            return $"{base.ToString()} {sb}";
        }
    }
}
