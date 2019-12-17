const persons = require("../controllers/persons");

module.exports = (app) => {
  
  //INDEX ROUTE
  app.get("/", (req,res) => persons.index(req,res))

  //ADD NAME TO DATABASE
  app.get("/new/:name/", (req,res) => persons.addPerson(req,res))

  //DELETE NAME FROM DATABASE
  app.get("/remove/:name/", (req,res) => persons.Remove(req,res))

  //VIEW PERSON
  app.get("/:name", (req,res) => persons.Show(req,res))

}