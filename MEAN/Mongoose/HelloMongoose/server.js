const express = require("express"),
  app = express(),
  port = 8000,
  server = app.listen(port, ()=> console.log(`Listening on port ${port}`))
const mongoose = require("mongoose");
mongoose.connect('mongodb://localhost/name_of_your_DB', {useNewUrlParser: true, useUnifiedTopology:true});

const UserSchema = new mongoose.Schema({
  name: String,
  age: Number
});

const User = mongoose.model("User", UserSchema);





//ROOT ROUTE
app.get("/", (req,res) => {
  User.find()
    .then(data => res.render("index", {users : data}))
    .catch(err => res.json(err));
});

//USER POST ROUTE
app.post("/users", (req,res) => {
  const user = new User();
  user.name = req.body.name;
  user.age = req.body.age;
  user.save()
    .then(newUserData => {
      console.log("user created: ", newUserData)
      res.redirect('/');
    })
    .catch(err => console.log(err));
});