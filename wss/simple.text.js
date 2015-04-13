var arDrone = require('ar-drone');
var client = arDrone.createClient();
console.log("Server started");

client.takeoff();
client.land();

client.after(5000, function() {
	this.land();
});