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

mongoose.connect("mongodb://localhost/MessageBoard", {useNewUrlParser: true, useUnifiedTopology: true});

//MODELS//

const CommentSchema = new mongoose.Schema({
  name: {
    type: String,
    required: [true, "Comments must have commenter name"],
    minlength: [2, "Commenters name must be at least 2 charcaters"]
  },
  content: {
    type: String,
    required: [true, "Please add comment"],
    minlength: [5, "Comments must be at least 5 characters"]
  }
}, {timestamps:true});

const MessageSchema = new mongoose.Schema({
  name: {
    type: String,
    required: [true, "Posts must have commenter name"],
    minlength: [2, "Creators name must be at least 2 charcaters"]
  },
  post: {
    type: String,
    required: [true, "Please add message"],
    minlength: [5, "Message must be at least 5 characters"]
  },
  comments: [CommentSchema]
}, {timestamps:true});

const Comment = mongoose.model("Comment", CommentSchema);
const Message = mongoose.model("Message", MessageSchema);

//ROUTES//

//** home page route**//

app.get("/", (req,res) => {
  Message.find()
  .then(messages => res.render("index", {allMessages : messages}))
  .catch(err => res.json(err.errors));
})

//** post message **//

app.post("/messages", (req,res) => {
  Message.create(req.body)
    .then(message => {
      res.redirect("/")
    })
    .catch(err => res.json(err.errors));
})

//** post comment **//

app.post("/comments/:id", (req,res) => {
  Comment.create(req.body)
    .then(comment => {
      Message.findByIdAndUpdate(req.params.id, 
        {$push:{comments:comment}})
      .then(result => res.redirect("/"))
      .catch(err => res.json(err.errors))
    })
    .catch(err => res.json(err.errors));
})