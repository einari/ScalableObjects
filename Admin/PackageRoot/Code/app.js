var express = require("express");
var path = require("path");

var app = express();

app.use(express.static(path.join(__dirname, "public")));

app.get("/test", function (request, response) {
    response.send("Hello world");
    response.sendStatus(200);
});

module.exports = app;