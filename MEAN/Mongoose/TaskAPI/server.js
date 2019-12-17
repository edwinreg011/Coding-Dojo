const express = require("express"),
  app = express(),
  port = 8000,
  mongoose = require("mongoose"),
  server = app.listen(port, () => console.log(`listening on port ${port}`));

app.use(express.json());


require("./server/config/database")
require("./server/config/routes")(app)

app.use(express.static( __dirname + '/public/dist/public' ));