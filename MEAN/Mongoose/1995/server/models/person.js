const mongoose = require("mongoose");

const PersonSchema = new mongoose.Schema({
  name:{
    type: String,
    required: [true, "A person must have a name."],
  }
}, {timestamps:true});

mongoose.model("Person", PersonSchema);