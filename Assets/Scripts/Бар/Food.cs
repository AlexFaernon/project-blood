using System;

public static class Food
{
    public static BloodSample CurrentPackage;

    
    public class Ingredient
    {
        public readonly Fruits Fruit;
        public readonly Condition Condition;
        public readonly Miscellaneous Miscellaneous;

        public Ingredient(Miscellaneous miscellaneous)
        {
            Miscellaneous = miscellaneous;
        }

        public Ingredient(Fruits fruit, Condition condition)
        {
            Fruit = fruit;
            Condition = condition;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ingredient other))
            {
                return false;
            }

            return other.Fruit == Fruit && other.Condition == Condition || other.Miscellaneous == Miscellaneous;
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
