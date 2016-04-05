var fileSystem = require("fs");
var geode = require("geode");
var readLine = require("readline");

console.log("Geosearch . . .");
console.log(process.cwd());

var fileInputPath = "Geonamesclient/placenames.txt";

readLine.createInterface({
    input: fileSystem.createReadStream(fileInputPath),
    terminal: false
}).on("line", function (placename) {
    console.log(placename);
    console.log();
    
    var geo = new geode("demo", {language: "en"});

    geo.search({name : placename}, function(err, results) {
        if (err) {
            console.error(err);
            return;
        }
        
        var wgs84 = {
            wkid : 4326  
        };
        var nextResult, jsonGeometry;
        var geonames = results.geonames;
        for (var index in geonames) {
            nextResult = geonames[index];
            jsonGeometry = {
                x : nextResult.lng,
                y : nextResult.lat,
                spatialReference : wgs84       
            };
            console.log(JSON.stringify(jsonGeometry));
        }
    });
});