const mongoose = require('mongoose');

const PetSchema = new mongoose.Schema({

     name: {
          type: String,
          required: [true, "Pets must have a name!"],
          minlength: [3, "Pet's name must be atleast 3 characters!"]
     },
     
     type: {
          type: String, 
          required: [true, "Please tell us the pet's species!"],
          minlength: [3, "Species must be 3 characters or more!"]
     },

     description: {
          type: String,
          required: [true, "Pet description is requiered"],
          minlength: [3, "Description must be 3 characters or more!"]
     },

     skill1: {
          type: String
     },

     skill2: {
          type: String
     },

     skill3: {
          type: String
     },

},{timestamps: true});

mongoose.model("Pet", PetSchema)