using System;
using System.Collections.Generic;

public static class Food
{
    //todo save
    public static Dictionary<object, int> Ingredients = new Dictionary<object, int>
    {
        {Fruits.Apple, 5},
        {Fruits.Lemon, 5},
        {Fruits.Lime, 5},
        {Fruits.Pineapple, 5},
        {Fruits.Orange, 5},
        {Fruits.Celery, 5},
        {Miscellaneous.Carnation, 5},
        {Miscellaneous.Coffee, 5},
        {Miscellaneous.Honey, 5},
        {Miscellaneous.Pepper, 5}
    };

    [Serializable]
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
    
    [Serializable]
    public class Cocktail
    {
        public readonly string Name;
        public readonly string Description;
        public readonly BloodSample BloodSample;
        public readonly bool PureBlood;
        public readonly bool IsShitted;

        public Cocktail(string name, string description, BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
        {
            Name = name;
            Description = description;
            BloodSample = new BloodSample(bloodGroup, rh, bloodQuality);
        }

        public static Cocktail GetBadCocktail()
        {
            return new Cocktail();
        }

        public static Cocktail GetPureBlood(BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
        {
            return new Cocktail(bloodGroup, rh, bloodQuality);
        }

        private Cocktail(BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
        {
            PureBlood = true;
            BloodSample = new BloodSample(bloodGroup, rh, bloodQuality);
        }
        
        private Cocktail()
        {
            IsShitted = true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Cocktail other))
            {
                return false;
            }

            return other.Name == Name;
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }
    }
    
    public enum Fruits
    {
        Lime,
        Lemon,
        Apple,
        Orange,
        Pineapple,
        Celery
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
        Carnation
    }
}
