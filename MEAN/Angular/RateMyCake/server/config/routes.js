const cakes = require('../controllers/cakes');

module.exports = (app) => {
    app.get('/api/cakes', (req,res) => cakes.index(req,res))
    app.get('/api/cakes/:id', (req,res) => cakes.show(req,res) )
    app.post('/api/cakes/create', (req,res) => cakes.create(req,res))
    app.put('/api/cakes/update/:id', (req,res) => cakes.update(req,res))
    app.delete('/api/cakes/destroy/:id', (req,res) => cakes.destroy(req,res))
    app.post('/api/rating/create/:cakeId', (req,res) => cakes.createRating(req,res))
}