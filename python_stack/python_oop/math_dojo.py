class MathDojo:

  def __init__(self):
    self.result = 0

  def add(self, *nums):
    self.adding = 0
    for value in nums:
      self.adding = self.adding + value
    self.result = self.result + self.adding
    return self

  def subtract(self, *nums):
    self.sub = 0
    for value in nums:
      self.sub = self.sub + value
    self.result = self.result - self.sub
    return self

md = MathDojo()

x = md.add(1,2,3).add(10).add(30,14).subtract(12, 7, 12).subtract(10).subtract(12,9).result

print(x)