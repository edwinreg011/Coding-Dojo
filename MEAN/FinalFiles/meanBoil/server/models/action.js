const mongoose = require('mongoose');

const ActionSchema = new mongoose.Schema({

     name: {
          type: String
     },
     
},{timestamps: true});

mongoose.model("Action", ActionSchema)