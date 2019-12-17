using System;
using System.Collections.Generic;

namespace DeckOfCards.Models
{
    public class Player
    {
        public string Name;
        public List<Card> hand;

        public Player(string name)
            {
                Name = name;
                hand = new List<Card>();
            }

        public Card draw(Deck newdeck)
        {
            Card newcard = newdeck.deal();
            hand.Add(newcard);
            Console.WriteLine($"{Name} drew {newcard.suit} of {newcard.stringVal}");
            return newcard;
        }

        public Card discard(int idx)
        {
            if (idx < 0 || idx >= hand.Count)
            {
                Console.WriteLine("CARD DOES NOT EXIST AT INDEX");
                return null;
            }
            else 
            {
                Card det = hand[idx];
                hand.RemoveAt(idx);

                Console.WriteLine($"{Name} discarded {det.suit} of {det.stringVal}");
                return det;
            }
        }
    }
}