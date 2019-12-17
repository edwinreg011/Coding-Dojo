const express = require("express"),
  app = express(),
  port = 8000,
  mongoose = require("mongoose"),
  server = app.listen(port, () => console.log(`listening on port ${port}`));


//SETUPS FOR STATIC AND VIEWS//

app.use(express.static(__dirname + "/static"));
app.use(express.urlencoded({extended:true}));
app.set("view engine", "ejs");
app.set("views", __dirname + "/views");

//MONGOOSE - DATABASE STUFF//

mongoose.connect("mongodb://localhost/MonDash", {useNewUrlParser: true, useUnifiedTopology: true});

//MODELS//

const AnimalSchema = new mongoose.Schema({
  name:{
    type: String,
    required: [true, "An animal name is required"],
    minlength: [3, "Please input name longer than 3 characters"]
  },
  stripes:{
    type: Number,
    required: [true, "Please input number of stripes on animal"],
    min: [1, "Animals must have stripes"]
  },
  description:{
    type: String,
    required: [true, "Must have a description"],
    maxlength: [30, "Too long of a description"]
  }
}, {timestamps:true});

const Animal = mongoose.model("Animal", AnimalSchema);

//ROUTES//

//** index route **//

app.get("/", (req,res) => {
  Animal.find()
    .then(animals => res.render("index", {allAnimals : animals}))
    .catch(err => res.json(err.errors));
})

//** new animal form **//

app.get("/mongooses/new", (req,res) => {
  res.render("new");
})

//** post new animal **//

app.post("/mongooses", (req,res) => {
  Animal.create(req.body)
    .then(animal => {
      res.redirect("/");
    })
    .catch(err => res.json(err.errors));
})

//** show animal information **//

app.get("/mongooses/:id", (req, res) => {
  Animal.findById(req.params.id)
    .then(animal => res.render("show", {animal: animal}))
    .catch(err => res.json(err.errors));
})

//** edit animal form **//

app.get("/mongooses/edit/:id", (req, res) => {
  Animal.findById(req.params.id)
    .then(animal => res.render("edit", {animal: animal}))
    .catch(err => res.json(err.errors));
})

//** post update **//

app.post("/mongooses/:id", (req,res) => {
  Animal.findOneAndUpdate({_id: req.params.id}, req.body, {runValidators:true})
    .then(animal => res.redirect("/"))
    .catch(err => res.json(err.errors));
})

//** delete Animal **//

app.get("/mongooses/destroy/:id", (req,res) => {
  Animal.deleteOne({_id: req.params.id})
    .then(result => res.redirect("/"))
    .catch(err => res.json(err.errors));
})