var countryCodes = require("i18n-iso-countries");
var fileSystem = require("fs");
var geode = require("geode");
var readLine = require("readline");

console.log("Geosearch . . .");
console.log(process.cwd());

var fileInputPath = "placenames.txt";

var features = [];
var fileOutputPath = "features.json";
var writeStream = fileSystem.createWriteStream(fileOutputPath);
var hasWrittenFeature = false;

var readInterface = readLine.createInterface({
    input: fileSystem.createReadStream(fileInputPath),
    terminal: false
});
readInterface.on("line", function (line) {
    var splittedLine = line.split(",");
    if (splittedLine.length < 8) {
        return;
    }
    
    var placename = splittedLine[1].trim(" ");
    var countryName = splittedLine[2].trim(" ");
    var language = "en";
    var countryCode = countryCodes.getAlpha2Code(countryName, language);
    
    var geo = new geode("gisfromscratch", { 
        language : language
    });
    
    var searchOptions = {
        name : placename,
        country : countryCode,
        maxRows : 1
    };

    geo.search(searchOptions, function(err, results) {
        if (err) {
            console.error(err);
            return;
        }
        
        var wgs84 = {
            wkid : 4326  
        };
        var nextResult, nextFeature, jsonGeometry, attributes;
        var geonames = results.geonames;
        for (var index in geonames) {
            nextResult = geonames[index];
            jsonGeometry = {
                x : nextResult.lng,
                y : nextResult.lat,
                spatialReference : wgs84       
            };
            attributes = {
                "date": splittedLine[0],
                "city" : splittedLine[1],
                "country" : splittedLine[2],
                "perpetrator" : splittedLine[3],
                "weapon" : splittedLine[4],
                "injuries" : splittedLine[5],
                "fatalities" : splittedLine[6],
                "description" : splittedLine[7],
                "geoname" : nextResult.name    
            };
            nextFeature = {
                geometry : jsonGeometry,
                attributes : attributes    
            };
            
            var featureString = JSON.stringify(nextFeature);
            if (hasWrittenFeature) {
                featureString = "," + featureString;
            }
            var writeFailed = !writeStream.write(featureString);
            if (writeFailed) {
                writeStream.once("drain", function() {
                    writeStream.write(featureString);
                });
            } else {
                hasWrittenFeature = true;
            }
        }
    });
});