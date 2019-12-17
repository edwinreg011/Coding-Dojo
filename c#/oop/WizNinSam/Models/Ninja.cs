using System;

namespace WizNinSam.Models
{
    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            int dmg = 5 * Dexterity;
            target.Health -= dmg;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} kicked {target.Name} for {dmg} damage");
            Console.ResetColor();
            target.ShowStats();

            Random extraDmg = new Random();
            if(extraDmg.Next(0,101) <= 20)
            {
                target.Health -= 10;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{Name} punched {target.Name} for an extra 10 damage");
                Console.ResetColor();
                target.ShowStats();
            }
            return target.Health;
        }

        public void Steal(Human target)
        {
            int steals = 5; 
            target.Health -= steals;
            health += 5;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} stole 5 health from {target.Name}");
            Console.ResetColor();
            target.ShowStats();
        }
    }
}