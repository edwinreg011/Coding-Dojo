dojo = {
  'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
  'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}

def printInfo(somelist):
  for i in somelist:
    # print(somelist[i])
    print(len(i))
    for x in somelist[i]:
      print(x)
  # print(somelist["locations"][0])

printInfo(dojo)