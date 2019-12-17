const mongoose = require('mongoose');

const RatingSchema = new mongoose.Schema({
    stars: {
        type: Number,
        required: [true, "Gotta rate that cake"],
        min: [1, "The cake cant be that bad"],
        max: [5, "The cake cant be that good"]
    },
    comment: {
        type: String,
        required: [true, "Say something"],
        min: [3, "what?"]
    }
},{timestamps:true})

const CakeSchema = new mongoose.Schema({
    baker: {
        type: String,
        required: [true, "cake must have baker"]
    },
    url: {
        type: String,
        required: [true, "Upload image"]
    },
    ratings: [RatingSchema]
},{timestamps:true})

mongoose.model("Rating", RatingSchema)
mongoose.model("Cake", CakeSchema)