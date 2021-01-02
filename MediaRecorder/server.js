const express = require('express'),
  https = require('https'),
  app = express(),
  fs = require('fs');
var bodyParser = require('body-parser')

const pkey = fs.readFileSync('./ssl/key.pem'),
  pcert = fs.readFileSync('./ssl/cert.pem'),
  options = {key: pkey, cert: pcert, passphrase: '123456789'};
var sslSrv = null;
 
// use express static to deliver resources HTML, CSS, JS, etc)
// from the public folder 
app.use(express.static('public'));
app.use(bodyParser.raw({limit: '50mb',type: 'application/octet-stream'}));
app.use(express.raw());

app.use(function(req, res, next) {
  if(req.headers['x-forwarded-proto']==='http') {
    return res.redirect(['https://', req.get('Host'), req.url].join(''));
  }
  next();
});


app.post('/video-chunck/:filename', async(req, res,next) => {
	let writeStream = fs.createWriteStream(req.params.filename+'.webm', { flags: 'a' });
    await writeStream.write(req.body);
	writeStream.on('finish', () => {
    console.log('wrote all data to file');
      });
       // close the stream
      writeStream.end();
	
    res.sendStatus(200);
});


// start server (listen on port 443 - SSL)
sslSrv = https.createServer(options, app).listen(443);
console.log("The HTTPS server is up and running");
