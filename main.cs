using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace messi
{

    public interface Item
    {
        String name();
        Packing packing();
        float price();
    }

    public interface Packing
    {
        String pack();
    }

    public class Wrapper : Packing
    {
        public String pack()
        {
            return "Wrapper";
        }
    }

    public class Bottle : Packing
    {
        public String pack()
        {
            return "Bottle";
        }
    }

    public abstract class Burger : Item
    {
        public Packing packing()
        {
            return new Wrapper();
        }
        public abstract float price();
        public abstract String name();
    }

    public abstract class coldDrink : Item
    {
        public Packing packing()
        {
            return new Bottle();
        }
        public abstract float price();
        public abstract String name();
    }

    public class VegBurger : Burger
    {
        public override float price()
        {
            return 25.0f;
        }

        public override string name()
        {
            return "Veg Burger";
        }
    }

    public class ChickenBurger : Burger
    {
        public override float price()
        {
            return 50.5f;
        }

        public override string name()
        {
            return "Chicken Burger";
        }
    }

    public class Coke : coldDrink
    {
        public override float price()
        {
            return 30.0f;
        }

        public override string name()
        {
            return "Coke";
        }
    }

    public class Pepsi : coldDrink
    {
        public override float price()
        {
            return 35.0f;
        }

        public override string name()
        {
            return "Pepsi";
        }
    }

    public class Meal
    {
        private List<Item> items = new List<Item>();
        public void addItem(Item item)
        {
            items.Add(item);
        }
        public float getCost()
        {
            float cost = 0.0f;
            foreach (Item item in items)
            {
                cost += item.price();
            }
            return cost;
        }
        public void showItems()
        {
            foreach (Item item in items)
            {
                System.Console.WriteLine("Item: " + item.name());
                System.Console.WriteLine("Packing: " + item.packing().pack());
                System.Console.WriteLine("Price " + item.price());
                System.Console.ReadKey();
            }
        }
   
    }


    public class MealBuilder
    {
        public Meal prepareVegMeal()
        {
            Meal meal = new Meal();
            meal.addItem(new VegBurger());
            meal.addItem(new Coke());
            return meal;
        }
        public Meal prepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.addItem(new ChickenBurger());
            meal.addItem(new Pepsi());
            return meal;
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            MealBuilder mealBuilder = new MealBuilder();
            Meal vegMeal = mealBuilder.prepareVegMeal();
            System.Console.WriteLine("Veg Meal");
            Console.ReadKey();
            vegMeal.showItems();
            System.Console.WriteLine("Total Cost " + vegMeal.getCost());
            Console.ReadKey();
            Meal nonVegMeal = mealBuilder.prepareNonVegMeal();
            System.Console.WriteLine("\n\nNonVeg Meal");
            Console.ReadKey();
            nonVegMeal.showItems();
            System.Console.WriteLine("Total cost" + nonVegMeal.getCost());
            Console.ReadKey();

        }
    }
}