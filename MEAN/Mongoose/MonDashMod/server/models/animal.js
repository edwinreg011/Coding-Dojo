const mongoose = require("mongoose");

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

mongoose.model("Animal", AnimalSchema);