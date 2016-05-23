var express = require("express");
var path = require("path");
var http = require("http");
var querystring = require("querystring");

var app = express();
app.use(express.static(path.join(__dirname, "public")));


function callAPI(method, data) {
    var path = "/api/objects";

    var postData = data;

    var options = {
        hostname: "localhost",
        port: 8163,
        path: path,
        method: method,
        headers: {
            "Content-Type": "application/x-www-form-urlencoded;charset=utf-8",
            "Content-Length": Buffer.byteLength(postData)
        }
    };

    var request = http.request(options, function (response) {
        console.log("API call result");
        console.log("  StatusCode : " + response.statusCode);
        console.log("  Headers : " + response.headers);

        response.on("data", function (data) {
            process.stdout.write(data);
        });
    });

    request.on("error", function (error) {
        console.error(error);
    });

    request.write(postData);
    request.end();
}

app.post("/sphere", function (request, response) {
    console.log("Adding sphere");
    callAPI("POST", "=sphere");
});

app.delete("/sphere", function (request, response) {
    console.log("Deleting sphere");
    callAPI("DELETE", "=");
});

app.post("/box", function (request, response) {
    console.log("Adding box");
    callAPI("POST", "=box");
});

app.delete("/box", function (request, response) {
    console.log("deleting box");
    callAPI("DELETE", "=");
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