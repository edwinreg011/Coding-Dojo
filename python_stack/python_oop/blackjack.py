import deck_of_cards 
from random import randint


#total

# def total(player_hand):
#   player.total = 0
#   player.total = player.total += Card.values[] 


#score

def score(player_hand, dealer_hand):
  if total(player_hand) == 21
    print(f"You have Blackjack, you win")
  elif total(dealer_hand) == 21
    print(f"Dealer has Blackjack, you lose")
  elif total(player_hand) > 21
    print(f"You busted, dealer wins")
  elif total(dealer_hand) > 21
    print(f"Dealer busted, you win")
  elif total(dealer_hand) > total(player_hand)
    print(f"Dealer has {dealer_hand}, you lose")
  elif total(player_hand) > total(dealer_hand)
    print(f"Dealer has {dealer_hand}, you win")


