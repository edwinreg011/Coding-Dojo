using System;
using System.Collections.Generic;

namespace HungryNinja.Models
{
    public class Food : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo()
        {
            return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }


        public Food(string name, int cal, bool spice, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spice;
            IsSweet = sweet;
        }
    }

    public class Buffet
    {
        public List<IConsumable> Menu;

        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Tacos", 500, true, false),
                new Food("Carrots", 50, false, false),
                new Food("Sushi", 100, false, false),
                new Food("Burger", 800, true, true),
                new Food("Turkey", 175, false, true),
                new Food("Candy Corn", 73, false, true),
                new Food("Wings", 200, true, true),
                new Drink("Coke", 20, false),
                new Drink("Pepsi", 15, false),
                new Drink("Water", 0, false),
                new Drink("Juice", 50, false)
            };
        }
        public IConsumable Serve()
        {
            Random rand = new Random();
            int randInt = rand.Next(0, Menu.Count);
            return Menu[randInt];
        }
    }
}