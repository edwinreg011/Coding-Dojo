class User:
  def __init__(self, name, email):
    self.name = name
    self.email = email
    self.account = BankAccount(0.02, 0)
    
  def make_deposit(self, amount):
    self.account = self.account + amount
    return self

  def make_withdrawl(self, amount):
    self.account = self.account - amount
    return self

  def display_account_balance(self):
    print(f"User: {self.name}, Balance: ${self.account}")
    return self

  def transfer_money(self, other_user, amount):
    self.account = self.account - amount
    other_user.account = other_user.account + amount
    return self

class BankAccount:
  def __init__ (self, int_rate, account_balance):
    self.int_rate = int_rate
    self.account_balance = account_balance

  def make_deposit(self, amount):
    self.account_balance = self.account_balance + amount
    return self

  def make_withdrawl(self, amount):
    self.account_balance = self.account_balance - amount
    return self

  def display_account_balance(self):
    print(f"Balance: ${self.account_balance}")
    return self

  def yield_interest(self):
    if(self.account_balance < 0):
      self.account_balance = self.account_balance
    else: 
      self.interest_amt = self.account_balance * self.int_rate
      self.account_balance= self.account_balance + self.interest_amt
    return self
  
  

edwin = User("edwin", "123@gmail.com")
ed = User("ed", "456@gmail.com")
eddy = User("eddy", "789@gmail.com")

edwin.account.make_deposit(100).make_deposit(50).make_deposit(10).make_withdrawl(50).yield_interest().display_account_balance()

ed.account.make_deposit(100).make_deposit(200).make_withdrawl(50).make_withdrawl(25).yield_interest().display_account_balance()

eddy.account.make_deposit(1000).make_withdrawl(100).make_withdrawl(50).make_withdrawl(25).yield_interest().display_account_balance()