#countdown
def countdown(input):
  listcount = []
  for x in range(input, 0, -1):
    listcount.append(x)
  print(listcount)
print(countdown(5))

#print and return
newlist = [10, 22]
def print_return(newlist):
  print(newlist[0])
  return newlist[1]
print(print_return(newlist))

# first plus length 
newlist = [1,2,3,4,5,6]
def first_plus(newlist):
  sum = newlist[0] + len(newlist)
  return(sum)
print(first_plus(newlist))

# values greater than second
list = [10,3,27,20,1]
def val_greater_than(list):
  newlist = []
  for val in range (0, len(list), 1):
    if list[val] > list[1]:
      newlist.append(list[val])
  if len(newlist) <= 2:
    return False
  return newlist
  
print(val_greater_than(list))

#this length that value 
size = 10 
value = 8
def size_val():
  newlist = []
  for x in range (0,size , 1):
    newlist.append(value)
  return newlist
print(size_val())