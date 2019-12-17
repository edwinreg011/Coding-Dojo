using System;

namespace WizNinSam.Models
{
    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Health = 200;
        } 

        public override int Attack(Human target)
        {
            base.Attack(target);

            if(target.Health < 50)
            {
                target.Health = 0;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{Name} finished {target.Name}, {target.Name} has 0 health.");
                Console.ResetColor();
            }
            target.ShowStats();
            return target.Health;
        }

        public void Meditate()
        {
            int meditate = 100;
            health = meditate;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} meditated to restore health.");
            Console.ResetColor();
            ShowStats();
        }
    }
}