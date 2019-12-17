//CHALLENGE 1

let students = [
    {name: 'Remy', cohort: 'Jan'},
    {name: 'Genevieve', cohort: 'March'},
    {name: 'Chuck', cohort: 'Jan'},
    {name: 'Osmund', cohort: 'June'},
    {name: 'Nikki', cohort: 'June'},
    {name: 'Boris', cohort: 'June'}
];

function one(arr)
{
  for(var key of arr)
  {
    console.log("Name: " + key.name + ", " + "Cohort: " + key.cohort)
  }
}
one(students);


console.log("******************")

//CHALLENGE 2 

let users = {
  employees: [
      {'first_name':  'Miguel', 'last_name' : 'Jones'},
      {'first_name' : 'Ernie', 'last_name' : 'Bertson'},
      {'first_name' : 'Nora', 'last_name' : 'Lu'},
      {'first_name' : 'Sally', 'last_name' : 'Barkyoumb'}
  ],
  managers: [
    {'first_name' : 'Lillian', 'last_name' : 'Chambers'},
    {'first_name' : 'Gordon', 'last_name' : 'Poe'}
  ]
};

function printUsers(users) {

  var count = 1;

  console.log('EMPLOYEES')
  for (var employee of users.employees) {

      empLen = employee.first_name.length + employee.last_name.length 


      empStr = count + " - " + employee.last_name + ", " + employee.first_name + " -"


      console.log(empStr, empLen);
      count++
  }


  console.log('MANAGERS')
  for (var manager of users.managers) {

      mgrLen = manager.first_name.length + manager.last_name.length
      
      
      mgrStr = count + " - " + manager.last_name + ", " + manager.first_name + " -"


      console.log(mgrStr, mgrLen);
      count++
  }
}

printUsers(users);