using System;
using System.Collections.Generic;
using UnityEngine;

public static class Food
{
    public static Dictionary<object, int> Ingredients = new Dictionary<object, int>
    {
        {Fruits.Apple, 3},
        {Fruits.Lemon, 3},
        {Fruits.Lime, 3},
        {Fruits.Pineapple, 3},
        {Fruits.Orange, 3},
        {Fruits.Celery, 3},
        {Miscellaneous.Carnation, 3},
        {Miscellaneous.Coffee, 3},
        {Miscellaneous.Honey, 3},
        {Miscellaneous.Pepper, 3}
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
        public readonly string Order;
        private readonly string color;
        public readonly int Level;
        public readonly BloodSample BloodSample;
        public readonly HashSet<Ingredient> Ingredients;
        public readonly bool PureBlood;
        public readonly bool IsShitted;

        public Cocktail(string name, string description, string order, int level, string color, BloodGroup bloodGroup,
            Rh rh, BloodQuality bloodQuality, HashSet<Ingredient> ingredients)
        {
            Name = name;
            Description = description;
            Order = order;
            Level = level;
            this.color = color;
            BloodSample = new BloodSample(bloodGroup, rh, bloodQuality);
            Ingredients = ingredients;
        }

        public static Cocktail GetBadCocktail(BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
        {
            return new Cocktail(false, bloodGroup, rh, bloodQuality);
        }

        public static Cocktail GetPureBlood(BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
        {
            return new Cocktail(true, bloodGroup, rh, bloodQuality);
        }

        public Color GetColor()
        {
            if (ColorUtility.TryParseHtmlString("#" + color, out var parsedColor))
            {
                return parsedColor;
            }

            throw new ArgumentException("cant parse color");
        }

        private Cocktail(bool isBlood, BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
        {
            BloodSample = new BloodSample(bloodGroup, rh, bloodQuality);
            if (isBlood)
            {
                PureBlood = true;
                color = "ff0000";
                return;
            }

            IsShitted = true;
            color = "412414";
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
