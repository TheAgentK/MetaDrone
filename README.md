# nexGEN META-DRONE
![alt text](http://meta-drone.siedentopp.eu/img/controle_02.jpg "Logo Title Text 1")

nexGEN META-DRONE lets one control an AR.Drone 2.0 with Meta SpaceGlasses, an augmented reality headset.

## How Do I Control It?

Everything should be visible through a HUD on the screen.
[More information available here](http://meta-drone.siedentopp.eu/#control)

### Altitude

The drone's altitude is controlled by the y position of one's right hand. Raising one's hand will make the drone rise, and dropping one's hand will let it descend. 

### Yaw

The yaw, or rotation, of the drone is controlled by the x position of one's hand. Moving one's hand to the right will make the drone rotate clockwise. Moving one's hand to the left will do the opposite.

### Pitch

Pitch, or forwards movement, is controlled by the y position of one's left hand. Raising one's hand will make the drone move forwards, and dropping one's hand will move it backwards.

### Landing

Landing, at the moment, is triggered when one makes a tight fist with both hands. Unfortunately, the tightness of one's hand often varies. 

**Sometimes, the drone may not land. To land in an emergency, hit `Ctrl-C` in the command line.**

### Dead Zones

If you'd like the drone to not move, leave your hands in the middle of the axis related to your control. For instance, to stop the drone from changing altitude, leave your right hand in the middle of the y axis. 

## Using This

To run the program, one will need 
- an AR.Drone 2.0, 
- Meta Glasses, 
- and a computer. 

First, 
  1. connect to the drone's wifi after powering the drone on. 
  2. Run `game.exe` file in the `game` folder after plugging in and connecting the Meta Glasses.
  3. Then, once the GUI is visible, run the `main.js` file located in the `wss` directory. 
  4. The drone start to rise after you open the left Hand and make a fist with the right Hand.
  6. Once it has taken off, open both Hands and you should be able to control the drone!

## In Action

Flight Demo 1 | Flight Demo 2
------------- | -------------
[![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/oG0BTWE2OyM/0.jpg)](http://www.youtube.com/watch?v=oG0BTWE2OyM) | [![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/khywcFAqvlM/0.jpg)](http://www.youtube.com/watch?v=khywcFAqvlM)

Further development by [Karsten Siedentopp](https://github.com/TheAgentK) at [Fachhoschule Stralsund](http://www.fh-stralsund.de).

[More information available here](http://meta-drone.siedentopp.eu)
