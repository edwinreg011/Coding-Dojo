using System;

namespace HungryNinja.Models
{
    public class SpiceHound : Ninja
    {
    public override bool IsFull{
            get{
                if(calorieIntake >= 1200)
                {
                    return true;
                }
                return false; 
            }
        }

        public override void Eat(IConsumable item){
            if(IsFull == false)
            {
                if(item.IsSpicy){
                    calorieIntake -= 5;
                }
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine(item.GetInfo());
            }
            else
            {
                Console.WriteLine($"SpiceHound is full!");
                
            }
        }
    }
}