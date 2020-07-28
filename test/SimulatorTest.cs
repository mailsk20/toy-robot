using Moq;
using System;
using ToyRobot.Constants;
using ToyRobot.Interfaces;
using ToyRobot.Logic;
using Xunit;

namespace ToyRobot.Test
{
    public class SimulatorTest
    {
        private Mock<IRobot> robot;
        private Simulator simulator;

        public SimulatorTest()
        {
            robot = new Mock<IRobot>();
            simulator = new Simulator(robot.Object);
        }

        [Theory]
        [InlineData(0, 0, Direction.North)]
        [InlineData(1, 2, Direction.East)]
        [InlineData(3, 4, Direction.South)]
        [InlineData(4, 0, Direction.West)]
        public void Execute_InputValidCommand_PlaceRobot(int x, int y, string direction)
        {
            robot.Setup(r => r.Place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            simulator.Execute($"PLACE {x},{y},{direction}");

            robot.Verify(r => r.Place(x, y, direction), Times.Once);
        }

        [Fact]
        public void Execute_InputValidCommand_MoveRobot()
        {
            robot.Setup(r => r.Move());

            simulator.Execute("MOVE");

            robot.Verify(r => r.Move(), Times.Once);
        }

        
        [Fact]
        public void Execute_InputValidCommand_TurnLeftRobot()
        {
            robot.Setup(r => r.Left());

            simulator.Execute("LEFT");

            robot.Verify(r => r.Left(), Times.Once);
        }

        [Fact]
        public void Execute_InputValidCommand_TurnRightRobot()
        {
            robot.Setup(r => r.Right());

            simulator.Execute("RIGHT");

            robot.Verify(r => r.Right(), Times.Once);
        }

        [Fact]
        public void Execute_InputValidCommand_RobotReport()
        {
            robot.Setup(r => r.Report());

            simulator.Execute("REPORT");

            robot.Verify(r => r.Report(), Times.Once);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("A")]
        [InlineData("BB")]
        [InlineData("CCC")]
        [InlineData("PLACE x,0,NORTH")]
        [InlineData("PLACE 1,x,EAST")]
        [InlineData("PLACE 1111,0,SOUTH")]
        [InlineData("PLACE 0,222,WEST")]
        public void Execute_InputInvalidCommand_RobotNotExecute(string command)
        {
            robot.Setup(r => r.Place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            robot.Setup(r => r.Move());
            robot.Setup(r => r.Left());
            robot.Setup(r => r.Right());
            robot.Setup(r => r.Report());

            simulator.Execute(command);

            robot.Verify(r => r.Place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Never);
            robot.Verify(r => r.Move(), Times.Never);
            robot.Verify(r => r.Left(), Times.Never);
            robot.Verify(r => r.Right(), Times.Never);
            robot.Verify(r => r.Report(), Times.Never);
        }
    }
}
