var countryCodes = require("i18n-iso-countries");
var fileSystem = require("fs");
var geode = require("geode");
var readLine = require("readline");
var uniRest = require("unirest");

console.log("Geosearch . . .");
console.log(process.cwd());

var geonamesUser = "demo";
var featureServiceUrl = "http://services6.arcgis.com/Non4T7MSCBOZeZLO/ArcGIS/rest/services/RandIncidents/FeatureServer/0";
var fileInputPath = "placenames.txt";

var readInterface = readLine.createInterface({
    input: fileSystem.createReadStream(fileInputPath),
    terminal: false
});
readInterface.on("line", function (line) {
    var pattern = /,(?=(?:[^"]*"[^"]*")*[^"]*$)/gm;
    var splittedLine = line.split(pattern);
    if (splittedLine.length < 8) {
        return;
    }
    
    var trimPattern = /^\s+|"+|\s+$/gm;
    var placename = splittedLine[1].replace(trimPattern, "");
    var countryName = splittedLine[2].replace(trimPattern, "");
    var language = "en";
    var countryCode = countryCodes.getAlpha2Code(countryName, language);
    
    var geo = new geode(geonamesUser, { 
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
            
            //var featureString = JSON.stringify(nextFeature);
            var postUrl = featureServiceUrl + "/addFeatures";
            uniRest.post(postUrl)
                .headers({
                    "Accept" : "application/json",
                    "Content-Type" : "application/json"
                })
                .field("f", "json")
                .field("features", [ nextFeature ])
                .field("rollbackOnFailure", true)
                .end(function (response) {
                    console.log(response.body);
                });
        }
    });
});