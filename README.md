## Toy Robot Application

## Description:
The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5
units x 5 units. There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.

## Create an application that can read in commands of the following form

```
PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT
```

- `PLACE` will put the toy robot on the table in position `X,Y` and facing `NORTH`, `SOUTH`, `EAST` or
`WEST`.
- The origin (0,0) can be considered to be the `SOUTH WEST` most corner.
- The first valid command to the robot is a `PLACE` command, after that, any sequence of
commands may be issued, in any order, including another `PLACE` command. The application
should discard all commands in the sequence until a valid `PLACE` command has been
executed.
- `MOVE` will move the toy robot one unit forward in the direction it is currently facing.
- `LEFT` and `RIGHT` will rotate the robot 90 degrees in the specified direction without changing
the position of the robot.
- `REPORT` will announce the `X,Y and F` of the robot. This can be in any form, but standard
output is sufficient.
- A robot that is not on the table can choose the ignore the `MOVE`, `LEFT`, `RIGHT` and `REPORT`
commands.
- Input can be from a file, or from standard input, as the developer chooses.


## Get started

```
- A toy robot simulator written in Asp.Net Core 3.1 framework with C#
- Make sure you have the latest git, Visual Studio 2019, Asp.Net Core 3.1 framework installed on your machine
- I have used the Dependency Injection, TDD/Test, Documentation
```

#### Clone the repo from Github

```bash
$ git clone https://github.com/mailsk20/toy-robot.git
```

#### Build And Run Application

- Open Visual Studio 2019
- Open `REA-ToyRobot.sln` in visual studio
- Build the application
- Run application
- It will display the output of run Toy Robot commands
- All the commands are setupped in the text file, which you can modify.
- You can go to source code folder -> `src` folder -> `TestData` folder, there you can find the three text files, where you can update the new command to test the application.
- To update the text file name, you go to  `src` folder -> `Properties` folder -> `launchSettings.json` file. there you can update the `commandLineArgs` with the new text file name and run again application to verify the result.


## Completed application output screenshot

![alt screenshot](https://github.com/mailsk20/toy-robot/blob/master/ToyRobot%20Output1.jpg)

![alt screenshot](https://github.com/mailsk20/toy-robot/blob/master/ToyRobot%20Output2.jpg)

![alt screenshot](https://github.com/mailsk20/toy-robot/blob/master/ToyRobot%20Output3.jpg)
