# nexGEN META-DRONE
![alt text](http://theagentk.github.io/nexGEN-META-DRONE/img/controle_02.jpg "Logo Title Text 1")

nexGEN META-DRONE lets one control an AR.Drone 2.0 with Meta SpaceGlasses, an augmented reality headset.

## How do I control it?

Everything should be visible through a HUD on the screen.
[More information available here](http://theagentk.github.io/nexGEN-META-DRONE/#control)

### Altitude

The drone's altitude is controlled by the y position of the right hand. Raising the hand will make the drone rise, and dropping the hand will let it descend. 

### Yaw

The yaw, or rotation, of the drone is controlled by the x position of the right hand. Moving the right hand to the rightside will make the drone rotate clockwise. Moving the hand to the leftside will do the opposite.

### Pitch

Pitch, or forwards movement, is controlled by the z position of the left hand. Move the left hand forwards will make the drone move forwards, and move the hand backwards will move it backwards.

### Landing
Make a tight fist with both hands to land the drone. Unfortunately, the tightness of the hand often varies.

**Sometimes, the drone may not land. To land in an emergency, hit `Ctrl-C` in the command line.**

### Dead zones

If you would like the drone to stop moving, leave your hands in the middle of the axis related to your control. For example, to stop the drone from changing altitude, leave your right hand in the middle of the y axis. 

## Using this

To run the program, you will need 
- an AR.Drone 2.0, 
- Meta Glasses, 
- and a computer. 

Next steps: 
  1. Power up the drone and connect to the drone's wifi. 
  2. Plugging in and connecting the Meta Glasses and run `game.exe` file in the `game` folder.
  3. Then, once the GUI is visible, run the `main.js` file located in the `wss` directory. 
  4. The drone start to rise after you open the left hand and make a fist with the right hand.
  6. After the drone is lifted, open both hands and you should be able to control the drone!

## In action

Flight demo 1 | Flight demo 2
------------- | -------------
[![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/oG0BTWE2OyM/0.jpg)](http://www.youtube.com/watch?v=oG0BTWE2OyM) | [![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/khywcFAqvlM/0.jpg)](http://www.youtube.com/watch?v=khywcFAqvlM)

Further development by [Karsten Siedentopp](https://github.com/TheAgentK) at [University of Applied Siences Stralsund](http://www.fh-stralsund.de).

[More information available here](http://theagentk.github.io/nexGEN-META-DRONE)
