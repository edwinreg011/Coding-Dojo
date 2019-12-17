require("../models/person")

const mongoose = require("mongoose"),
  Person = mongoose.model("Person");

module.exports = {

  index: (req,res) => {
    Person.find()
      .then(persons => res.json({allPersons : persons}))
      .catch(err => res.json({errors : err.errors}));
  }, 

  addPerson: (req,res) => {
    Person.create({name : req.params.name})
      .then(person => res.redirect("/"))
      .catch(err => res.json({errors : err.errors}));
  },

  Remove: (req,res) => {
    Person.deleteOne({name : req.params.name})
    .then(result => res.redirect("/"))
    .catch(err => res.json({errors : err.errors}));
  }, 

  Show: (req,res) => {
    Person.find({name : req.params.name})
      .then(person => res.json(person))
      .catch(err => res.json({errors : err.errors}));
  }

}