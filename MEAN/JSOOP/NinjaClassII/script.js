class Ninja{
  constructor(name, health = 100, speed = 3, strength = 3){
    this.name = name;
    this.health = health;
    this.speed = speed;
    this.strength = strength;
  }

  sayName (){
    console.log(`My ninja name is ${this.name}!`);
  }

  showStats(){
    console.log(`Name: ${this.name} Health: ${this.health} Speed: ${this.speed} Strength: ${this.strength}`);
  }

  drinkSake(){
    this.health += 10;
  }

  punch(target){
    if(target instanceof Ninja == true){ 
      target.health -= 5;
      console.log(`${this.name} punched ${target.name}`);
    }
    if(target instanceof Ninja == false)
    {
      console.log("Ninja does not exist");
    }
  }

  kick(target){
    if(target instanceof Ninja == true){ 
      var attack = 15 * this.strength;
      target.health -= attack;
      console.log(`${this.name} kicked ${target.name} for ${attack} damage`);
    }
    if(target instanceof Ninja == false)
    {
      console.log("Ninja does not exist");
    }
  }
}

class Person{
  constructor (name){
    this.name = name;
  }
}

var red = new Ninja("Red Ninja");

var blue = new Ninja("Blue Ninja");

var ed = new Person("edwin");

red.kick(ed);
