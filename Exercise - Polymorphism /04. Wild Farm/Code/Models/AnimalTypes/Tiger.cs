﻿using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Exceptions;

namespace WildFarm.Models.AnimalTypes;
public class Tiger : Feline {
    private const double IncrementIncreaseWeight = 1.00;
    private ICollection<Type> foodTypes = new List<Type> { typeof(Meat)};
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) {
    }

    public override string ProduceSound() => "ROAR!!!";
    

    public IReadOnlyCollection<Type> FoodTypes => (IReadOnlyCollection<Type>)foodTypes;

    public override void FeedIt(Food food) {
        if (!foodTypes.Any(f => f.Name == food.GetType().Name)){
            string exceptionMessages = String.Format(ExceptionMessages.InvalidFoodException, this.GetType().Name, food.GetType().Name);
            throw new ArgumentException(exceptionMessages);
        }

        int quantity = food.Quantity;
        base.Weight += quantity * IncrementIncreaseWeight;
        base.FoodEaten += quantity;
    }
}

