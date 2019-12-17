#biggie size
testlist = [-1, 3, 5, -5]
for val in range (0, len(testlist), 1):
    if(testlist[val] >= 0):
      testlist[val] = 'Big'
  return (testlist)

#count positives
testlist = [-1, 1, 1, 1]
def fxn(testlist):
  count = 0
  for val in range (0, len(testlist), 1):
    if( testlist[val] > 0):
      count = count + 1
  testlist.pop(testlist[len(testlist) -1])
  testlist.append(count)
  return (testlist)
print(fxn(testlist))

#sum total
list = [1, 2, 3, 4]
def sum(list):
  sum = 0
  for val in range (0, len(list), 1):
    sum = sum + list[val]
  return sum

#average 
list = [1, 2, 3, 4]
def fxn(list):
  return sum(list) / len(list)
print(fxn(list))

#length
list = [1, 2, 3]
def fxn(list):
  return len(list)
print(fxn(list))

#min
list = [2, 4, 7 ,10]
def fxn(list):
  min = list[0]
  for val in range (1, len(list), 1):
    if(min > list[val]):
      min = list[val]
  return min
print(fxn(list))

#maximum
list = [2, 4, 7 ,10]
def fxn(list):
  max = list[0]
  for val in range (1, len(list), 1):
    if(max < list[val]):
      max = list[val]
  return max
print(fxn(list))

#reverse list 
list = [1, 2, 3, 4, 5]
def fxn(list):
  newlist = []
  for x in range (len(list)-1, -1, -1):
    newlist.append(list[x])
  return newlist
print(fxn(list))