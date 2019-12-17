const express = require("express");
    app = express(),
    port = 8000,
    path = require("path"),
    server = app.listen(port, () => console.log("Listening on port 8000"))

app.use(express.json());

require('./server/config/database')
require('./server/config/routes')(app)

app.use(express.static( __dirname + '/public/dist/public' ));

///***  REROUTES TO ANGULAR PROJECT IF IT DOESNT HIT EXPRESS ROUTES ***///

app.all("*", (req,res,next) => {
    res.sendFile(path.resolve("public/dist/public/iindex.html"))
});