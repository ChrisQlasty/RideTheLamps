# RideTheLamps

This is a code of PC C# app, which intercepts output from the touchless gesture sensor, interprets it and sends appropriate commands to Philips Hue bridge to change lights in your surrounding.

The output of the gesture sensor contains 4 fields: hand pose code, performed gesture code, hand position in _x_ axis, hand position in _y_ axis (both numbers expressed in percentages).

## Overview
Optical gesture sensor [[1]](https://ieeexplore.ieee.org/abstract/document/8004989/) sends information about recognized hand pose/gesture via UART interface. Ride the Lamps app opens appropriate port and listens for incoming packages. If recognized commands come, it sends appropriate requests to a Philips HUE bridge utilizing dedicated REST queries. As a result, control of light sources is taken.
![Overview image](./sources/schemeRtL.png)
With discrete static gestures active lamp source is done - e.g. single finger selects right lamp, two fingers select second lamp. Discrete dynamic gestures (hand swipes) can turn on/off active lamp depending on the direction of performed movement. </br>
With continuous gestures, e.g. by slowly moving single finger in front of the sensor, brightness of active lamp can be changed.
</br>
Application allows to choose between two active light selection methods (different gestures trigger other lighting system responses) and two brightness adjustment methods (in _x_ and in _y_ axes).

## Demo
One of implemented light source selection methods in action is presented below. Selected lamp/s blink in notification and the control is taken over it. After that, user can e.g. turn it off/on or precisely change brightness level. Gesture sensor is mounted within the light switch.

| Discrete gestures </br> Left lamp selection |   Discrete gestures </br> Right lamp selection  |
|----------------|----------------|
| <p align="center"><img src="./sources/Lsel.gif"></p> | <p align="center"><img src="./sources/Rsel.gif"></p>  |
| <p align="center">__Discrete gestures </br> Both lamps selection__</p> |   <p align="center">__Continuous gestures </br> Lamp brightness adjustment__ </p>|
| <p align="center"><img src="./sources/Bsel.gif"></p>  | <p align="center"><img src="./sources/cont.gif"></p>  |

### References
[1] [*"Pose classification in the gesture recognition using the linear optical sensor"*, K. Czuszynski, J. Ruminski, J. Wtorek](https://ieeexplore.ieee.org/abstract/document/8004989/)</br>
TBA - Research utilizing this application is to be presented at IECON'18.
