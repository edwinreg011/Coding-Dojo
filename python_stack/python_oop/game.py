class Card():
​
    def __init__ (self, suit, value, rank):
        self.suit = suit
        self.value = value
        self.rank = rank
​
    def __str__(self):
        return (f"Card: {self.rank} of {self.suit}s")
​
    def __repr__(self):
        return (f"Card: {self.rank[0]}{self.suit[0]}")
​
class Deck():
​
    def __init__(self):
        self.contents = []
        self.initialize_deck()
    
    def initialize_deck(self):
        suits = ['heart', 'club', 'diamond', 'spade']
        values = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
        for suit in suits:
            for value in values:
                if value == 1:
                    new_card = Card(suit, value, 'Ace')
                elif value == 11:
                    new_card = Card(suit, value, 'Jack')
                elif value == 12:
                    new_card = Card(suit, value, 'Queen')
                elif value == 13:
                    new_card = Card(suit, value, 'King')
                else:
                    new_card = Card(suit, value, str(value))
                self.contents.append(new_card)
    # method to draw card from deck
    # - remove card from contents and return it

​
new_deck = Deck()
# print(new_deck.contents)
​
# player_hand = []
# card = new_deck.contents.pop()
# player_hand.append(card)