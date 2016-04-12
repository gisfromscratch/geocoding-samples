var countryCodes = require("i18n-iso-countries");
var fileSystem = require("fs");
var geode = require("geode");
var readLine = require("readline");
var stdio = require("stdio");
var uniRest = require("unirest");

console.log("Geosearch . . .");
console.log(process.cwd());

var options = stdio.getopt({
    "config" : {
        key : "c",
        args : 1,
        description : "The app configuration containing all options."    
    },
    
    "geonamesUser" : {
        key : "u",
        args : 1,
        description : "The geonames user name."    
    },
    
    "portalToken" : { 
        key : "t", 
        args : 1,
        description : "The portal token."
     },
     
     "featureServiceUrl" : {
         key : "s",
         args : 1,
         description : "The feature service url."
     },
     
     "fileInputPath" : {
         key : "f",
         args : 1,
         description : "The path to the input file."
     }
});

// Force app configuration first
if (options.config) {
    options = JSON.parse(fileSystem.readFileSync(options.config, "utf-8"));
}

var geonamesUser = options.geonamesUser;
var portalToken = options.portalToken;
var featureServiceUrl = options.featureServiceUrl;
var fileInputPath = options.fileInputPath;

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
            throw err;
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
            
            var addFeaturesOption = [ nextFeature ];
            var featureString = JSON.stringify(addFeaturesOption);
            var postUrl = featureServiceUrl + "/addFeatures";
            uniRest.post(postUrl)
                .headers({
                    "Accept" : "application/json",
                    "Content-Type" : "application/json"
                })
                .query({
                    "token" : portalToken,
                    "f" : "json",
                    "rollbackOnFailure" : true,
                    "features" : featureString
                })
                .end(function (response) {
                    console.log(response.body);
                });
        }
    });
});