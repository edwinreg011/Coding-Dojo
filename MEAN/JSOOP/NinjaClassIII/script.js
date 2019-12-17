class Ninja{
  constructor(name, health = 100, speed = 3, strength = 3){
    this.name = name;
    this.health = health;
    this.speed = speed;
    this.strength = strength;
  }

  sayName(){
    console.log(`My ninja name is ${this.name}!`);
  }

  showStats(){
    console.log(`Name: ${this.name} Health: ${this.health} Speed: ${this.speed} Strength: ${this.strength}`);
  }

  drinkSake(){
    this.health += 10;
    console.log(`${this.constructor.name} ${this.name} drank sake.`)
  }

  punch(target){
    if(target instanceof Ninja == true){ 
      target.health -= 5;
      console.log(`${this.name} punched ${target.name}`);
    }
    if(target instanceof Ninja == false)
    {
      console.log("Target Ninja does not exist!");
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



class Sensai extends Ninja{
  constructor(name, health = 200, speed = 10, strength = 10, wisdom = 10){
    super(name, health, speed, strength);
    this.wisdom = wisdom;
  }

  showStats(){
    super.showStats();
    console.log(`Wisdom: ${this.wisdom}`)
  }

  kick(target){
    super.kick(target);
    if(target.health <= 0){
      console.log(`${target.name} has been destroyed!`);c
    }
  }

  speakWisdom(){
    super.drinkSake();
    console.log("speaks wise words");
  }
}





var Ed = new Sensai("Edwin");

Ed.speakWisdom();

Ed.showStats();


