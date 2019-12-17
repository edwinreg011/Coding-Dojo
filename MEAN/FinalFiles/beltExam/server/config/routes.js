const pets = require('../controllers/pets');


module.exports = (app) => {

    app.get('/api/pets', (req, res) => pets.index(req,res))

    app.get('/api/pets/:id', (req, res) => pets.show(req,res))

    app.post('/api/pets/create', (req, res) => pets.create(req,res)) 

    app.put('/api/pets/update/:id', (req, res) => pets.update(req,res))

    app.delete('/api/pets/destroy/:id', (req, res) => pets.destroy(req,res))

}