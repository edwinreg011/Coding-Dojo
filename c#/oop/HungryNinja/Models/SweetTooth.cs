using System;

namespace HungryNinja.Models
{
    public class SweetTooth : Ninja
    {


    public override bool IsFull{
            get{
                if(calorieIntake >= 1500)
                {
                    return true;
                }
                return false; 
            }
        }

        public override void Eat(IConsumable item){
            if(IsFull == false)
            {
                if(item.IsSweet){
                    calorieIntake += 10;
                }
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                item.GetInfo();
            }
            else
            {
                Console.WriteLine($"SweetTooth is full!");
            }
        }
    }
}