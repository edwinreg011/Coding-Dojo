using System;

namespace human.Models
{
    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        public int Health
        {
            get {return health;}
            set {health = value;}
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100; 
        }

        public Human(string name, int strength, int intelligence, int dexterity, int hel)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            health = hel; 
        }

        public int Attack(Human target)
        {
            int damage = Strength * 5;
            target.health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            Console.WriteLine($"{target.Name} Health: {target.health}");
            Console.WriteLine($"{Name} Health: {health}");
            return target.health;
        }
    }
}