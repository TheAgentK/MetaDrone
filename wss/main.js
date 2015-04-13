var io = require('socket.io')({
	transports: ['websocket'],
});

var arDrone = require('ar-drone');
var client  = arDrone.createClient();
console.log("Server started");

io.attach(4567);
acount = 0;//altitude counter
pcount = 0;//pitch counter
ycount = 0;
max = 10;
killed = false;
var up = false;

landed = false;
rised = true;
fallen = false;
spinLeft = false;
spinRight = false;

client.setMaxListeners(100000000000000);
//client.disableEmergency();

process.on('SIGINT', function(){
	console.log("land");
	client.land(function(){
		process.exit(0);
	})
	
})

io.on('connection', function(socket){
	console.log("CONNECTED");

	socket.on('takeoff', function(){
		if(up || killed) // Wenn bereits gestartet hier beenden // Wenn bereits gestop hier beenden
			return;
		
		console.log("Take off");
		
		client.takeoff(function(){
			up = true;
			killed = false;
			console.log("---> Taken off");
		});
	})

	socket.on('rise', function(){
		if(!up)
			return;
		
		acount++;
		
		if(acount > max){
			acount = 0;
			client.up(0.5)
			client.after(500, function(){
				if(up){
					client.up(0);
					console.log("------> Rise Stop");
				}
			})
			console.log("-> Rise");
		}
	})

	socket.on('fall', function(){
		if(!up)
			return;
			
		acount++;
		
		if(acount > max){
			acount = 0;
			client.down(0.5)
			client.after(500, function(){
				if(up){
					client.down(0);
					console.log("-----> Fall Stop");
				}
			})
			console.log("-> Fall");
		}
	})


	socket.on('forwards', function(){
		if(!up)
			return;
			
		pcount++;
		if(pcount > max){
			pcount = 0;
			client.front(0.1)
			client.after(200, function(){
				if(up){
					client.front(0);
					console.log("-----> Front Stop");
				}
			})
			console.log("-> Front");
		}
	})

	socket.on('backwards', function(){
		if(!up)
			return;
		
		pcount++;
		if(pcount > max){
			pcount = 0;
			client.back(0.1)
			client.after(200, function(){
				if(up){
					client.back(0);
					console.log("-----> Back Stop");
				}
			})
			console.log("-> Back");
		}
	})

	socket.on('right', function(){
		if(!up)
			return;
		ycount++;
		
		if(ycount > max){
			ycount = 0;
			client.clockwise(0.5)
			client.after(200, function(){
				if(up){
					client.clockwise(0);
					console.log("-----> CW Stop");
				}
			})
			console.log("-> CW");
		}
	})

	socket.on('left', function(){
		if(!up)
			return;
		
		ycount++;
		if(ycount > max){
			ycount = 0;
			client.counterClockwise(0.5)
			client.after(200, function(){
				if(up){
					client.counterClockwise(0);
					console.log("-----> CCW Stop");
				}
			})
			console.log("-> CCW");
		}
	})

	socket.on('kill', function(){//land drone
		if(killed || !up){//already triggered this...
			return;
		}
		
		up = false; //this is so the other methods don't fire...
		killed = true;
		console.log("KILL triggered");
		client.stop();
		client.land(function(){
			console.log("Landed");
			up = false;
			killed = false;
		});


	})

	socket.on('disconnect', function(){
		client.stop();
		client.land();
		console.log("Disconnected");
	})
	
	socket.on('stop', function(){
		if(!up)
	 		return;
		
	 	client.stop();
	})

	
})
