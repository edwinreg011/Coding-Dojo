using System;
using basics.Models;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Vehicle(5, "Green");

            Console.WriteLine(v.Color);
        }
    }
}
