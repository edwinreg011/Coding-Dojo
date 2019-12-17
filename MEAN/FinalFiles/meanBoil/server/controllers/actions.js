require('../models/action')

const mongoose = require('mongoose'),
    Action = mongoose.model("Action");

module.exports = {

    index: (req, res) => {
        Action.find()
            .then(result => res.json({ results: result}))
            .catch(err => res.json({ errors: err.errors }));
    },

    show: (req, res) => {
        Action.findById(req.params.id)
        .then(result => res.json({ results: result}))
        .catch(err => res.json({ errors: err.errors }));
    },

    create: (req, res) => {
        Action.create(req.body)
            .then(result => res.json({ results: result }))
            .catch( err => res.json({ errors: err.errors }));
    },

    update: (req, res) => {
        Action.findOneAndUpdate({_id: req.params.id}, req.body,{runValidators: true, useFindAndModify: false})
            .then(result => res.json({ results: result }))
            .catch(err => res.json({ errors: err.errors }));
    },

    destroy: (req,res) => {
        Action.deleteOne({_id:req.params.id})
            .then(result => res.json({ results: result }))
            .catch(err => res.json({ errors: err.errors }));
    },

}