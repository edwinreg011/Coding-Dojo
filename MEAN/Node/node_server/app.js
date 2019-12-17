const http = require('http');
const fs = require('fs');
//MOST IMPORTANT LINE
const server = http.createServer(function (request, response){
    console.log('client request URL: ', request.url);
    
    //ROOT ROUTE
    if(request.url === '/') {
        fs.readFile('index.html', 'utf8', function (errors, contents){
            response.writeHead(200, {'Content-Type': 'text/html'});  // send data about response
            response.write(contents);  //  send response body
            response.end(); // finished!
        });
    }

    //NINJA INFORMATION ROUTE
    else if (request.url === '/ninjas') {
      fs.readFile('ninjas.html', 'utf8', function (errors, contents) {
        response.writeHead(200, {'Content-Type': 'text/html'});
        response.write(contents);
        response.end();
      });
    }

    //DOJO FORM ROUTE
    else if (request.url === "/dojo/new") {
      fs.readFile('dojos.html', 'utf8', (errors, contents) => {
          response.writeHead(200, {'Content-type': 'text/html'});
          response.write(contents); 
          response.end();
      });
    }

    //404 RESPONSE
    else {
        response.writeHead(404);
        response.end('File not found!!!');
    }
});
// tell your server which port to run on
server.listen(6789);
// print to terminal window
console.log("Running in localhost at port 6789");
