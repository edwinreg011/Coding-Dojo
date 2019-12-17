

var users = [{name: "Michael", age: 37}, {name: "John", age: 30}, {name: "David", age: 27}];


//print johns age

console.log(users[1]["age"]); // bracket notation
console.log(users[1].age); //dot notation

//print michael's name

console.log(users[0]["name"]);

//loop name and age of everyone

for(var i = 0; i < users.length; i++){
  console.log(users[i].name + " - " + users[i].age);
  console.log(`${users[i].name} - ${users[i].age}`); //string interpolation 
}

var container = document.getElementById("container");
for(var i = 0; i < users.length; i++){
  let h2 = document.createElement("h2");
  h2.innerHTML = users[i].name;
  container.appendChild(h2);
  let p = document.createElement("p");
  p.innerHTML = users[i].age;
  container.appendChild(p);
}