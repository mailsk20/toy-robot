using System;
using System.Text.RegularExpressions;
using ToyRobot.Constants;
using ToyRobot.Interfaces;

namespace ToyRobot.Logic
{
    public class Simulator : ISimulator
    {
        private static readonly Regex _placeCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)");

        private readonly IRobot robot;

        public Simulator(IRobot robot)
        {
            this.robot = robot;
        }

        public void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            if (command == Command.Move) robot.Move();
            if (command == Command.Left) robot.Left();
            if (command == Command.Right) robot.Right();
            if (command == Command.Report)
            {
                Console.WriteLine(robot.Report());
                Console.WriteLine("");
            }

            var match = _placeCommand.Match(command);
            if (match.Success)
            {
                var xIsValid = int.TryParse(match.Groups[1].Value, out var x);
                var yIsValid = int.TryParse(match.Groups[2].Value, out var y);
                var direction = match.Groups[3].Value;
                if (xIsValid && yIsValid)
                {
                    robot.Place(x, y, direction);
                }
            }
        }
    }
}