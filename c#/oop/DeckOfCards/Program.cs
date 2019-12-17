using System;
using DeckOfCards.Models;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck mydeck = new Deck().reset().shuffle();
            Player edwin = new Player("Edwin");

            edwin.draw(mydeck);
            edwin.draw(mydeck);
            edwin.draw(mydeck);
            Console.WriteLine($"***** cards in hand {edwin.hand.Count} *****");
            edwin.discard(1);
            edwin.discard(1);
            edwin.discard(1);
            edwin.discard(0);
            Console.WriteLine($"***** cards in hand {edwin.hand.Count} *****");

        }
    }
}
