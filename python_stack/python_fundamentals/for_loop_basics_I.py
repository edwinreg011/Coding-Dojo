# basic

for x in range (0,151,1):
  print(x)

# multiples of 5

for x in range (5, 1001, 1):
  if( x % 5 == 0):
    print(x)

# counting, the dojo way

for x in range (1, 101, 1):
  if ( x % 10 == 0):
    x = "Coding Dojo"
  elif (x % 5 == 0):
    x = "coding"
  print(x)

  # whoa, that suckers huge 

sum = 0
for x in range (0, 500001, 1):
  if( x % 2 == 1):
    sum += x
print(sum)

# countdown by 4

for x in range (2018, 0, -1):
  if(x % 4 == 0):
    print(x)

# flexible counter

lowNum = num
highNum = num
mult = num
for x in range (lowNum, highNum +1, 1):
  if(x % mult == 0):
    print(x)