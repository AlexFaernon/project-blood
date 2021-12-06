using System.Collections.Generic;

public static class Food
{
    public static BloodSample CurrentPackage;
    public static Dictionary<object, int> Ingredients = new Dictionary<object, int>
    {
        {Fruits.Apple, 1},
        {Fruits.Lemon, 1},
        {Fruits.Lime, 1},
        {Fruits.Pineapple, 1},
        {Fruits.Orange, 2},
        {Miscellaneous.Carnation, 1},
        {Miscellaneous.Celery, 1},
        {Miscellaneous.Coffee, 2},
        {Miscellaneous.Honey, 1},
        {Miscellaneous.Pepper, 1}
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
        Peel,
        Fruit
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
