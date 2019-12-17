using System;

namespace NETCore
{
class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World!");
        //     for (int i = 0; i < 5; i++)
        // {
        //     Console.WriteLine(i);
        // }
        // Random rand = new Random();
        //     for (int i = 0; i <= 10; i++)
        // {
        //     Console.WriteLine(rand.Next(2, 8));
        // }

        string[] myCars = new string[] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx" };
        for (int idx = 0; idx < myCars.Length; idx++)
        {
            Console.WriteLine($"I own a {myCars[idx]}");
        }
        }
    }
}
