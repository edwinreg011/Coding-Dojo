using System;
using human.Models;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human you = new Human("Carl");
            Console.WriteLine(you.Name);
            Console.WriteLine($"Strength:{you.Strength}");
            Console.WriteLine($"Intelligence:{you.Intelligence}");
            Console.WriteLine($"Dexterity:{you.Dexterity}");
            Console.WriteLine($"Health:{you.Health}");

            Human me = new Human("Edwin", 10, 3, 5,30);
            Console.WriteLine(me.Name);
            Console.WriteLine($"Strength:{me.Strength}");
            Console.WriteLine($"Intelligence:{me.Intelligence}");
            Console.WriteLine($"Dexterity:{me.Dexterity}");
            Console.WriteLine($"Health:{me.Health}");

            me.Attack(you);
        }
    }
}
