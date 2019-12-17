const express = require("express"),
  app = express(),
  port = 8000,
  server = app.listen(port, () => console.log(`Listening on port ${port}`));

app.use(express.static(__dirname + "/static"));
app.set("view engine", "ejs");
app.set("views", __dirname + "/views");

var allCats = [
  {
    name : "Sorrow",
    url : "/sorrow",
    image : "cat1.jpeg",
    age : 1,
    food : "Paper",
    sleeping : [
      "In the dryer",
      "In the gutter",
      "On top of the stove"
    ]
  },
  {
    name : "Nibbles",
    url : "/nibbles",
    image : "cat2.jpg",
    age : 3,
    food : "Biscuts",
    sleeping : [
      "In the toilet",
      "In boxes",
      "the bed"
    ]
  },
  {
    name : "Grumpy Cat",
    url : "/grumpy",
    image : "cat3.png",
    age : "None of your business",
    food : "None of your business",
    sleeping : [
      "Go away",
      "Stop bothering me",
      "Why are you still here"
    ]
  }
]

app.get("/", (req, res) => {
  res.render("index");
});

app.get("/cats", (req, res) => {
  res.render("cats", {allCats : allCats});
});

app.get("/sorrow", (req, res) => {
  res.render("cat", {cat : allCats[0]});
});

app.get("/nibbles", (req, res) => {
  res.render("cat", {cat : allCats[1]});
});

app.get("/grumpy", (req, res) => {
  res.render("cat", {cat : allCats[2]});
});