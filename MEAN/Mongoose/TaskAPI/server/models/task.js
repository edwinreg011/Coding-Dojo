const mongoose = require("mongoose");

const TaskSchema = new mongoose.Schema({
  title:{
    type: String,
    required: [true, "A task must have a title!"]
  },
  description: {
    type: String,
    required: [true, "A task must have a description"]
  },
  completed: {
    type: Boolean,
    default: false
  }
}, {timestamps:true});

mongoose.model("Task", TaskSchema)