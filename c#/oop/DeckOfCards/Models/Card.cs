namespace DeckOfCards.Models
{
    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;


    public Card(string name, string st, int value)
        {
            stringVal = name;
            suit = st;
            val = value;
        }
    }
}