#1

x = [ [5,2,3], [10,8,9] ] 
students = [
    {'first_name':  'Michael', 'last_name' : 'Jordan'},
    {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

x[1][0] = 15

students[0]["last_name"] = "Bryant"

sports_directory["soccer"][0] = "andres"

z[0]['y'] = 30


print(x)

print(students)

print(sports_directory)

print(z)

#2

students = [
        {'first_name':  'Michael', 'last_name' : 'Jordan'},
        {'first_name' : 'John', 'last_name' : 'Rosales'},
        {'first_name' : 'Mark', 'last_name' : 'Guillen'},
        {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]


def iterateDictionary(students):
  for index in students:
    for k, v in index.items():
        print(f"{k} - {v}")

iterateDictionary(students)

#3

def iterateDictionary(students):
  for items in students:
    print(items['first_name'])

iterateDictionary(students)


def iterateDictionary(students):
  for items in students:
    print(items['last_name'])

iterateDictionary(students)

#4 

dojo = {
  'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
  'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}

def printInfo(somelist):
  for i in somelist:
    print(len(i))
    for x in somelist[i]:
      print(x)

printInfo(dojo)