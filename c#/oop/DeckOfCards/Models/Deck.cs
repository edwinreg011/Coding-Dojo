using System;
using System.Collections.Generic;

namespace DeckOfCards.Models
{
    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            reset();
        }

        public Deck reset()
        {
            cards = new List<Card>();
            string[] stringVals = {"Ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "Jack", "Queen", "King"};
            string [] suits = {"hearts", "diamonds", "spades", "clubs"};

            foreach(string suit in suits)
            {
                for(int i = 0; i < stringVals.Length; i++){
                    Card newcard = new Card(suit, stringVals[i], i+1);
                    cards.Add(newcard);
                    // Console.WriteLine($"Card: {newcard.suit} of {suit}");
                }
            }
            return this; 
        }

        public Deck shuffle()
        {
            Random rand = new Random();
            for ( int idx = cards.Count-1; idx > 0; idx--)
            {
                int randC = rand.Next(1,idx);
                Card temp = cards[randC];
                cards[randC] = cards[idx];
                cards[idx] = temp;
                // Console.WriteLine($"Card:{cards[idx].suit} of {cards[idx].stringVal}");
            }
            return this;
        }

        public Card deal()
        {
            if(cards.Count>0)
            {
                Card delt = cards[cards.Count-1];
                cards.RemoveAt(cards.Count-1);
                // Console.WriteLine($"Card Dealt: {delt.suit} of {delt.stringVal}");
                return delt;
            }
            else 
            {
                Console.WriteLine("##### NEW DECK BEING CREATED ####");
                reset();
                return deal();
            }
        }
    }
}