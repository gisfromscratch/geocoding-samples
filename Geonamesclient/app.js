var geode = require("geode");

console.log("Geosearch . . .");

var geo = new geode('demo', {language: 'en', country : 'US'});

geo.search({name :'Riverside'}, function(err, results) {
    if (null === err) {
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
    } else {
        console.error(err);
    }
});