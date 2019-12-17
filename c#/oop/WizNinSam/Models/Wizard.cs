using System;

namespace WizNinSam.Models
{
    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Intelligence = 25;
            health = 50;
        }

        public override int Attack(Human target)
        {
            int dmg = 5 * Intelligence;
            target.Health -= dmg;
            health += dmg;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} casted a spell on {target.Name} for {dmg} damage");
            Console.ResetColor();
            target.ShowStats();
            return target.Health;
        }

        public void Heal(Human target)
        {
            int heal = 10 * Intelligence;
            target.Health += heal;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} healed {target.Name} with a spell for {heal} health");
            Console.ResetColor();
            target.ShowStats();
        }
    }
}