require("../models/animalrr")

const mongoose = require("mongoose"),
  Animal = mongoose.model("Animal");

module.exports = {

  index: (req,res) => {
    Animal.find()
      .then(animals => res.render("index", {allAnimals : animals}))
      .catch(err => res.json(err.errors));
  },

  new: (req,res) => {
    res.render("new");
  },

  create: (req,res) => {
    Animal.create(req.body)
      .then(animal => {
        res.redirect("/");
      })
      .catch(err => res.json(err.errors));
  },

  show: (req,res) => {
    Animal.findById(req.params.id)
      .then(animal => res.render("show", {animal: animal}))
      .catch(err => res.json(err.errors));
  },

  edit: (req,res) => {
    Animal.findById(req.params.id)
      .then(animal => res.render("edit", {animal: animal}))
      .catch(err => res.json(err.errors));
  },

  update: (req,res) => {
    Animal.findOneAndUpdate({_id: req.params.id}, req.body, {runValidators:true})
      .then(animal => res.redirect("/"))
      .catch(err => res.json(err.errors));
  },

  destroy: (req,res) => {
    Animal.deleteOne({_id: req.params.id})
      .then(result => res.redirect("/"))
      .catch(err => res.json(err.errors));
  }

}