using System;
using System.Collections.Generic;

public static class Food
{
    public static BloodSample CurrentPackage;
    public static Dictionary<object, int> Ingredients = new Dictionary<object, int>
    {
        {Fruits.Apple, 0},
        {Fruits.Lemon, 0},
        {Fruits.Lime, 0},
        {Fruits.Pineapple, 0},
        {Fruits.Orange, 0},
        {Miscellaneous.Carnation, 0},
        {Miscellaneous.Celery, 0},
        {Miscellaneous.Coffee, 0},
        {Miscellaneous.Honey, 0},
        {Miscellaneous.Pepper, 0}
    };

    public class Ingredient
    {
        public readonly Fruits? Fruit;
        public readonly Condition? Condition;
        public readonly Miscellaneous? Miscellaneous;

        public Ingredient(Miscellaneous miscellaneous)
        {
            Miscellaneous = miscellaneous;
            Fruit = null;
            Condition = null;
        }

        public Ingredient(Fruits fruit, Condition condition)
        {
            Fruit = fruit;
            Condition = condition;
            Miscellaneous = null;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ingredient other))
            {
                return false;
            }

            return other.Fruit == Fruit && other.Condition == Condition || other.Miscellaneous == Miscellaneous;
        }

        public override int GetHashCode()
        {
            return
                (Fruit != null ? (int)Fruit : 0) * 100 +
                (Condition != null ? (int)Condition : 0) * 10 +
                (Miscellaneous != null ? (int)Miscellaneous : 0);
        }
    }
    
    public class Cocktail
    {
        public string Name;
        public string Description;
        public BloodGroup BloodGroup;
        public Rh Rh;
        public BloodQuality BloodQuality;

        public Cocktail(string name, string description, BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
        {
            Name = name;
            Description = description;
            BloodGroup = bloodGroup;
            Rh = rh;
            BloodQuality = bloodQuality;
        }
    }
    
    public enum Fruits
    {
        Lime,
        Lemon,
        Apple,
        Orange,
        Pineapple
    }
    
    public enum Condition
    {
        Pieces,
        Juice,
        Peel
    }
    
    public enum Miscellaneous
    {
        Pepper,
        Coffee,
        Ice,
        Honey,
        Celery,
        Carnation
    }
}
