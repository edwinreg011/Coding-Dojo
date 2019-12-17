const express = require("express");
const app = express();

app.get("/", (request, response) => {
  response.send("hello Express!");
});

app.get("/cats", (req, res) => {
  var cats_array = [
      {name : "nibbles", image : "./images/cat1.png"},
      {name : "chester", image : "./images/cat2.jpg"},
  ];
  res.render('cats', {cats: cats_array});
});

app.get("/nibbles", (req, res) => {
  var cats_array = [
      {name : "nibbles", food : "cheese", age : "5", spot : "porch, kitchen", image : "./images/cat1.png"},
  ];
  res.render('catsData', {cats: cats_array});
});

app.get("/chester", (req, res) => {
  var cats_array = [
      {name : "chester", food : "tacos", age : "53", spot : "roof", image : "./images/cat2.jpg"},
  ];
  res.render('catsData', {cats: cats_array});
});


app.listen(8000, () => console.log("listening on port 8000!"));
app.use(express.static(__dirname + "/static"));
app.set("view engine", "ejs");
app.set("views", __dirname + "/views");