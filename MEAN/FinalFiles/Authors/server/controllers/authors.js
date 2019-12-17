require('../models/author')

const mongoose = require('mongoose'),
    Author = mongoose.model("Author");

module.exports = {

    index: (req, res) => {
        Author.find()
            .then(result => res.json({ results: result}))
            .catch(err => res.json({ errors: err.errors }));
    },

    show: (req, res) => {
        Author.findById(req.params.id)
        .then(result => res.json({ results: result}))
        .catch(err => res.json({ errors: err.errors }));
    },

    create: (req, res) => {
        Author.create(req.body)
            .then(result => res.json({ results: result }))
            .catch( err => res.json({ errors: err.errors }));
    },

    update: (req, res) => {
        Author.findOneAndUpdate({_id: req.params.id}, req.body,{runValidators: true, useFindAndModify: false})
            .then(result => res.json({ results: result }))
            .catch(err => res.json({ errors: err.errors }));
    },

    destroy: (req,res) => {
        Author.deleteOne({_id:req.params.id})
            .then(result => res.json({ results: result }))
            .catch(err => res.json({ errors: err.errors }));
    },

}