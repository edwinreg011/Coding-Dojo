const express = require("express");
const app = express();

app.get("/", (request, response) => {
  response.send("hello Express!");
});

app.get("/cars", (req, res) => {
  var cars_array = [
      {image : "./images/car2.png"},
      {image : "./images/car3.png"},
  ];
  res.render('cars', {cars: cars_array});
});

app.get("/cats", (req, res) => {
  var cats_array = [
      {image : "./images/cat1.jpeg"},
      {image : "./images/cat2.png"},
  ];
  res.render('cats', {cats: cats_array});
});

app.get("/cars/new", (req, res) => {
  res.render("carform");
});


app.listen(8000, () => console.log("listening on port 8000!"));
app.use(express.static(__dirname + "/static"));
app.set("view engine", "ejs");
app.set("views", __dirname + "/views");