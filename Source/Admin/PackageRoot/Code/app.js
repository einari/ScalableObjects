var express = require("express");
var path = require("path");
var http = require("http");
var querystring = require("querystring");

var app = express();
app.use(express.static(path.join(__dirname, "public")));


function callAPI(method, data, callback) {
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

            if (callback) callback(data);
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
    response.sendStatus(200);
});

app.delete("/sphere", function (request, response) {
    console.log("Deleting sphere");
    callAPI("DELETE", "=");
    response.sendStatus(200);
});

app.post("/box", function (request, response) {
    console.log("Adding box");
    callAPI("POST", "=box");
    response.sendStatus(200);
});

app.delete("/box", function (request, response) {
    console.log("deleting box");
    callAPI("DELETE", "=");
    response.sendStatus(200);
});

app.get("/actors", function (request, response) {
    console.log("Getting actors from API")
    callAPI("GET", "", function (data) {
        console.log("Actors : " + data);
        response.send(data);
    });
});

app.use(function (request, response) {
    response.sendFile("./public/index.html");
});

module.exports = app;