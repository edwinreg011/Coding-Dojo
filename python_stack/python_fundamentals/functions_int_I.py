import random
def randInt(min = 0, max = 100):
    dif = max - min 
    if(max < min):
      return('error: min cannot be > max')
    else:
      num = random.random() *dif + min
    return round(num)


#print(randInt()) 		    # should print a random integer between 0 to 100
print(randInt())

#print(randInt(max=50)) 	    # should print a random integer between 0 to 50
print(randInt(max = 50))

#print(randInt(min=50)) 	    # should print a random integer between 50 to 100
print(randInt(min = 50))

#print(randInt(min=50, max=500))    # should print a random integer between 50 and 500
print(randInt(min = 50, max = 500))

#bonus
print(randInt(min = 100, max = 20))