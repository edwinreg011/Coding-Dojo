//1

console.log(hello);                                   
var hello = 'world';                                 

var hello;
console.log(hello);
var hello = "world";

//OUTPUT = "UNDEFINED"


//2

var needle = 'haystack';
test();
function test(){
	var needle = 'magnet';
	console.log(needle);
}

var needle = "haystack"
var test;
function test()
{
  var needle = "magnet";
  console.log(needle)
}

//OUTPUT "TEST IS NOT A FUNCITON"

//3
var brendan = 'super cool';
function print(){
	brendan = 'only okay';
	console.log(brendan);
}
console.log(brendan);


var brendan;
var print;
function print()
{
  brendan = "only okay";
  console.log(brendan);
}
console.log(brendan);

//OUTPUT = "SUPER COOL"


//4
var food = 'chicken';
console.log(food);
eat();
function eat(){
	food = 'half-chicken';
	console.log(food);
	var food = 'gone';
}

var food;
eat();
var food ="chicken";
function eat()
{
  food = "half-chicken";
  console.log(food);
  var food ="gone";
}

//OUTPUT = "CHICKEN //NL EAT IS NOT A FUNCTION"

//5
mean();
console.log(food);
var mean = function() {
	food = "chicken";
	console.log(food);
	var food = "fish";
	console.log(food);
}
console.log(food);

//OUTPUT = "MEAN IS NOT A FUNCTION"

//6
console.log(genre);
var genre = "disco";
rewind();
function rewind() {
	genre = "rock";
	console.log(genre);
	var genre = "r&b";
	console.log(genre);
}
console.log(genre);

var genre;
rewind();
var genre = "disco";
function rewind()
{
  genre = "rock";
  console.log(genre);
  var genre = "R&B";
  console.log(genre);
}
console.log(genre);

//OUTPUT = " REWIND IS NOT A FUNCTION, DISCO"

//7
dojo = "san jose";
console.log(dojo);
learn();
function learn() {
	dojo = "seattle";
	console.log(dojo);
	var dojo = "burbank";
	console.log(dojo);
}
console.log(dojo);

var dojo; 
learn();
dojo = "san jose"
function learn()
{
  dojo = "seattle";
  console.log(dojo);
  var dojo = "burbank";
  console.log(dojo);
}
console.log(dojo);

//OUTPUT seattle, burbank, san jose 