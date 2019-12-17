const express = require("express"),
  app = express(),
  port = 8000,
  mongoose = require("mongoose"),
  server = app.listen(port, () => console.log(`listening on port ${port}`));

app.use(express.static(__dirname + "/static"));
// app.use(express.urlencoded({extended:true}));
app.use(express.json());
app.set("view engine", "ejs");
app.set("views", __dirname + "/views");

require("./server/config/database")
require("./server/config/routes")(app)