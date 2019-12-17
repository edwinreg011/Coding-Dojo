class BankAccount:
  def __init__ (self, account_name, int_rate, account_balance):
    self.account_name = account_name
    self.int_rate = int_rate
    self.account_balance = account_balance

  def make_deposit(self, amount):
    self.account_balance = self.account_balance + amount
    return self

  def make_withdrawl(self, amount):
    self.account_balance = self.account_balance - amount
    return self

  def display_account_balance(self):
    print(f"Account: {self.account_name} Balance: ${self.account_balance}")
    return self

  def yield_interest(self):
    if(self.account_balance < 0):
      self.account_balance = self.account_balance
    else: 
      self.interest_amt = self.account_balance * self.int_rate
      self.account_balance= self.account_balance + self.interest_amt
    return self

account1 = BankAccount("account1", 0.05, 0)
account2 = BankAccount("account2", 0.05, 200)

#1
account1.make_deposit(100).make_deposit(200).make_deposit(50).make_withdrawl(100).yield_interest().display_account_balance()

#2
account2.make_deposit(100).make_deposit(500).make_withdrawl(500).make_withdrawl(50).make_withdrawl(50).make_withdrawl(100).yield_interest().display_account_balance()