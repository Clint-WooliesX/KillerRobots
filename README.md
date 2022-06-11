# KillerRobots API

## Overview
This API can be used to retrieve location data of 3 services to asssit with the invasion of the Killer robots. the 3 endpoints are:
* /RobotSpotted - Will return the location of the nearest water source to drown the robot.
* /RobotInjury - Will return the location of the nearest Hospital in the event you are injured by a robot.
* /RobotBounty - Will return the lcation of the nearest police station to receive a $10 bount per destroyed robot you turn in

## Usage
All end points are used in the same way:<br />
`LocationQuery=<Free form address string>` street#, street, suburb, city, state, postcode can all be used, country is not required as results are limited to Australia.<br />
`NumberOfResults=<integer>` 1-50 defines the maximum number of results to return.<br />

## Errors
Error **"403 Forbiden"** Any request orginating from outside of Australia are blocked to prevent DDoS attacks from the Killer Robot HQ

## Test_Rejection
the Last endpoint is for testing and development purposes only it rejects all requests returning the error 403 and recording the IP, city and country the request orignated from.


