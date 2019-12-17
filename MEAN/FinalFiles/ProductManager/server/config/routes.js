const actions = require('../controllers/actions');


module.exports = (app) => {

    app.get('/api/actions', (req, res) => actions.index(req,res))

    app.get('/api/actions/:id', (req, res) => actions.show(req,res))

    app.post('/api/actions/create', (req, res) => actions.create(req,res)) 

    app.put('/api/actions/update/:id', (req, res) => actions.update(req,res))

    app.delete('/api/actions/destroy/:id', (req, res) => actions.destroy(req,res))

}