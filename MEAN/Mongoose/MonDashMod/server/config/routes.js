const animals = require("../controllers/animals");

module.exports = (app) => {


  //** index route **//

  app.get("/", (req,res) => animals.index(req,res))

  //** new animal form **//

  app.get("/mongooses/new", (req,res) => animals.new(req,res))

  //** post new animal **//

  app.post("/mongooses", (req,res) => animals.create(req,res))

  //** show animal information **//

  app.get("/mongooses/:id", (req, res) => animals.show(req,res))

  //** edit animal form **//

  app.get("/mongooses/edit/:id", (req, res) => animals.edit(req,res))

  //** post update **//

  app.post("/mongooses/:id", (req,res) => animals.update(req,res))

  //** delete Animal **//

  app.get("/mongooses/destroy/:id", (req,res) => animals.destroy(req,res))

}