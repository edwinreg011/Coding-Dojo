const express = require("express"),
  app = express(),
  port = 8000,
  mongoose = require("mongoose"),
  server = app.listen(port, () => console.log(`listening on port ${port}`));


//SETUPS FOR STATIC AND VIEWS//

app.use(express.static(__dirname + "/static"));
app.use(express.urlencoded({extended:true}));
app.set("view engine", "ejs");
app.set("views", __dirname + "/views");

//MONGOOSE - DATABASE STUFF//

mongoose.connect("mongodb://localhost/QuotingDojo", {useNewUrlParser: true, useUnifiedTopology: true});

//MODELS//

const PostSchema = new mongoose.Schema({
  name:{
    type: String,
    required: [true, "A posters name is required"],
    minlength: [2, "Name must be atleast 2 characters"]
  },
  quote: {
    type: String,
    required: [true, "Please enter a quote to post"],
    minlength: [5, "Quote must be at least 5 characters long"]
  }
}, {timestamps:true});

const Post = mongoose.model("Post", PostSchema);

//ROUTES//

//** Index route **//

app.get("/", (req,res) => {mr
  res.render("index");
})

//** Create Quote **//

app.post("/quotes", (req,res) => {
  Post.create(req.body)
    .then(post => {
      res.redirect("/quotes")
    })
    .catch(err => res.json(err.errors));
})

//** Display all Quotes **//

app.get("/quotes", (req, res) => {
  Post.find()
    .then(posts => res.render("quotes", {allPosts : posts}))
    .catch(err => res.json(err.errors));
})