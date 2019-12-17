class Card{
  constructor(num, suit, strvalue){
    this.num = num;
    this.suit = suit;
    this.value = strvalue; 
  }

  show(){
    console.log(`Card: ${this.value} of ${this.suit}`)
  }
}

class Deck{
  constructor(){
    this.cards = [];
    this.suits = ["Hearts", "Diamonds", "Clubs", "Spades"];
    this.values = ["ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "jack", "queen", "king"];

    for(let suit in this.suits){
      for(let value in this.values){
        var aCard = new Card(this.suits[suit], this.values[value], value);
        this.cards.push(aCard);
      }
    }
  }
}

var Deck1 = new Deck();
console.log(Deck1);
