using System;
using System.Collections.Generic;

namespace HungryNinja.Models
{
    public abstract class Ninja
    {   
        protected int calorieIntake;
        public List<IConsumable> FoodHistory;


        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<IConsumable>();
        }


        public abstract bool IsFull{get;}

        public abstract void Eat(IConsumable item);
    }
}