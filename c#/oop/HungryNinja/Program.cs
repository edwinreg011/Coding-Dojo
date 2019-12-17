using System;
using HungryNinja.Models;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet eats = new Buffet();
            SweetTooth edwin = new SweetTooth();
            SpiceHound john = new SpiceHound();


            while(!edwin.IsFull)
            {
                // Console.WriteLine("here");
                edwin.Eat(eats.Serve());
            }
            // Console.WriteLine($"Full");
            
            while(!john.IsFull)
            {
                john.Eat(eats.Serve());
            }

        }
    }
}
