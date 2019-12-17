const express = require("express"),
  app = express(),
  port = 8000,
  server = app.listen(port, ()=> console.log(`Listening on port ${port}`))
  session = require("express-session");

app.use(express.static(__dirname + "/static"));
app.use(express.urlencoded({extended : true}));
app.set("view engine", "ejs");
app.set("views", __dirname +"/views");
app.use(session({
  secret: 'keyboardkitteh',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}));

//ROUTES//

//ROOT ROUTE
app.get("/", (req,res) => {
  res.render("index");
});

//SURVEY POST SUBMISSION
app.post("/process", (req,res) => {
  console.log(req.body);
  req.session.form = req.body;
  res.redirect("/success");
});

//SUCCESS ROUTE
app.get("/success", (req,res) => {
  console.log(req.session.form);
  res.render("success", {info : req.session.form});
});

//METHOD TO CLEAR SESSION DATA
app.get("/logout", (req,res) => {
  req.session.destroy();
  res.redirect("/");
})