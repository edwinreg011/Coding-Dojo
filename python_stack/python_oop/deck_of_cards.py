class Card():
    def __init__(self, suit, value, rank):
      self.suit = suit
      self.value = value
      self.rank = rank

    def __str__(self):
      return (f"Card: {self.rank} of {self.suit}s")

    def __repr__(self):
      if self.value == 10:
        return (f"Card: {self.rank[0]}{self.rank[1]}{self.suit[0]}")
      return (f"Card: {self.rank[0]}{self.suit[0]}")


class Deck():
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
                  new_card.value = 10
              elif value == 12:
                  new_card = Card(suit, value, 'Queen')
                  new_card.value = 10
              elif value == 13:
                  new_card = Card(suit, value, 'King')
                  new_card.value = 10
              else:
                  new_card = Card(suit, value, str(value))
              self.contents.append(new_card)
  # method to draw card from deck
  # - remove card from contents and return it
    def draw(self,player):
      player.hand.append(self.contents.pop())
      return player.hand[0]

class Player():
  def __init__(self):
      self.total = 0
      self.hand = []
class Dealer():
  def __init__(self):
      self.total = 0
      self.hand = []

# END OF CLASSES #
# START OF FUNCTIONS #
def initialDraw(player, dealer, deck):
  deck.draw(player)
  deck.draw(player)
  deck.draw(dealer)
  for i in range(0,len(player.hand),1):
      player.total = player.total + player.hand[i].value
  dealer.total = dealer.hand[0].value
def playerHit(player, dealer, deck):
  deck.draw(player)
  player.total = 0
  for i in range(0,len(player.hand),1):
      player.total = player.total + player.hand[i].value
  print("Player's Cards: ", player.hand,"Total:",player.total)
  if player.total > 21:
      checkWin(player, dealer)
def dealerHit(player, dealer, deck):
  deck.draw(dealer)
  dealer.total = 0
  for i in range(0,len(dealer.hand),1):
      dealer.total = dealer.total + dealer.hand[i].value
  print("Dealer's Cards: ", dealer.hand,"Total:",dealer.total)
  if dealer.total > 21:
      checkWin(player, dealer)
def dealerDecision(player, dealer, deck):
  deck.draw(dealer)
  dealer.total = 0
  for i in range(0,len(dealer.hand),1):
      dealer.total = dealer.total + dealer.hand[i].value
  print("Dealer shows hidden",dealer.hand[len(dealer.hand)-1],"[ Total:",dealer.total,"]")
  while(dealer.total >= 16):
      if dealer.total > 21:
          checkWin(player, dealer)
      else:
          dealerHit(player, dealer, deck)
          # for i in range(0,len(dealer.hand),1):
          #    dealer.total = dealer.total + dealer.hand[i].value
          print("Dealer's Cards:",dealer.hand,"[ Total:",dealer.total,"]")
  checkWin(player, dealer)
def checkWin(player, dealer):
  if player.total > 21:
      print("Player Busted")
  elif dealer.total > 21:
      print("Dealer Busted")
  elif player.total == 21:
      print("Player BLACKJACK!")
  elif dealer.total == 21:
      print("Dealer BLACKJACK!")
  elif player.total > dealer.total:
      print("Player Win")
  elif player.total < dealer.total:
      print("Dealer Win")
  elif player.total == dealer.total:
      print("Player and Dealer Push")
  quit()
def playGame():
  new_player = Player()
  new_dealer = Dealer()
  new_deck = Deck()
  initialDraw(new_player, new_dealer, new_deck)

print("Player's Cards: ", new_player.hand,"Total:",new_player.total)
print("Dealer's Cards: [?] ", new_dealer.hand,"Total:",new_dealer.total)
print("----------------------------")
print("hit or pass?")
  playerDecision = input()
    while(playerDecision != "pass"):
      if playerDecision == "hit":
          playerHit(new_dealer, new_player, new_deck)
      if playerDecision == "pass":
          dealerDecision(new_player, new_dealer, new_deck)
# END OF FUNCTIONS #
# START OF MAIN BODY #
playGame()
