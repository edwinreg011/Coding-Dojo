const express = require("express"),
  app = express(),
  port = 8000,
  server = app.listen(port, () => console.log(`Listening on port ${port}`));

const session = require('express-session');
app.use(session({
  secret: 'keyboardkitteh',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}));

app.use(express.static(__dirname + "/static"));
app.set("view engine", "ejs");
app.set("views", __dirname + "/views");


//ROOT ROUTE

app.get("/", (req, res) => {
  if(req.session.count == null)
  {
    req.session.count = 0;
  }
  else
  {
    req.session.count += 1;
  }
  res.render("index", {count : req.session.count});
});

app.get("/addTwo", (req, res) => {
    req.session.count += 1;
  res.redirect("/");
});

app.get("/reset", (req, res) => {
  req.session.count = null;
res.redirect("/");
});

