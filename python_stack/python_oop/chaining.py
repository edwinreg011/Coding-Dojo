class User:
  def __init__(self, name, email):
    self.name = name
    self.email = email
    self.account_balance = 0 
    
  def make_deposit(self, amount):
    self.account_balance = self.account_balance + amount
    return self

  def make_withdrawl(self, amount):
    self.account_balance = self.account_balance - amount
    return self

  def display_user_balance(self):
    print(f"User: {self.name}, Balance: ${self.account_balance}")
    return self

  def transfer_money(self, other_user, amount):
    self.account_balance = self.account_balance - amount
    other_user.account_balance = other_user.account_balance + amount
    return self


edwin = User("edwin", "123@gmail.com")
ed = User("ed", "456@gmail.com")
eddy = User("eddy", "789@gmail.com")


#1
edwin.make_deposit(100).make_deposit(50).make_deposit(10).make_withdrawl(50).display_user_balance()

#2
ed.make_deposit(100).make_deposit(200).make_withdrawl(50).make_withdrawl(25).display_user_balance()

#3
eddy.make_deposit(1000).make_withdrawl(100).make_withdrawl(50).make_withdrawl(25).display_user_balance()

#bonus
edwin.transfer_money(eddy, 50).display_user_balance()
eddy.display_user_balance()