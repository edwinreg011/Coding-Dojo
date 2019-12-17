const mongoose = require('mongoose');

const AuthorSchema = new mongoose.Schema({

     name : {
          type: String,
          required: [true, "Author must have a name"],
          minlength: [3, "Auhtor must have a name with 3 characters"]
     },

     book1: {
          type: String
     },

     book2: {
          type: String
     },

     book3: {
          type: String
     },

},{timestamps: true});

mongoose.model("Author", AuthorSchema)