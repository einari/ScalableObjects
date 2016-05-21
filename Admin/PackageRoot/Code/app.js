var express = require("express");
var path = require("path");

var app = express();

app.use(express.static(path.join(__dirname, "public")));

app.post("/sphere", function (request, response) {
    console.log("Adding sphere");
});

app.delete("/sphere", function (request, response) {
    console.log("Deleting sphere");
});

app.post("/box", function (request, response) {
    console.log("Adding box");
});


app.get("/actors", function (request, response) {
    var actors = [
        { partition: 1, actor: 1 },
        { partition: 1, actor: 2 },
        { partition: 1, actor: 3 },
        { partition: 2, actor: 4 },
        { partition: 2, actor: 5 },
        { partition: 2, actor: 6 }
    ];

    response.send(actors);
});

app.use(function (request, response) {
    response.sendFile("./public/index.html");
});

module.exports = app;