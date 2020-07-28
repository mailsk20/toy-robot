using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Constants;
using ToyRobot.Logic;
using Xunit;

namespace ToyRobot.Test
{
    public class RobotTest
    {
        private Robot robot;

        public RobotTest()
        {
            robot = new Robot(5, 5);
        }

        /* Place Function Tests
         *******************************/

        [Theory]
        [InlineData(0, 0, Direction.North)]
        [InlineData(1, 2, Direction.East)]
        [InlineData(3, 4, Direction.South)]
        [InlineData(4, 0, Direction.West)]
        public void Place_ValidInputParams_PlaceRobotPosition(int x, int y, string direction)
        {
            robot.Place(x, y, direction);

            robot.X.Should().Be(x);
            robot.Y.Should().Be(y);
            robot.Facing.Should().Be(direction);
        }

        [Theory]
        [InlineData(-1, -1, Direction.North)]
        [InlineData(-2, -2, Direction.East)]
        [InlineData(5, 5, Direction.South)]
        [InlineData(6, 6, Direction.West)]
        public void Place_InvalidInputParams_Discard(int x, int y, string direction)
        {
            robot.Place(x, y, direction);

            robot.X.Should().NotBe(x);
            robot.Y.Should().NotBe(y);
            robot.Facing.Should().NotBe(direction);
        }


        /* Move Function Tests
         *******************************/

        [Fact]
        public void Move_NorthDirection()
        {
            var direction = Direction.North;
            robot.Place(2, 2, direction);

            robot.Move();

            robot.X.Should().Be(2);
            robot.Y.Should().Be(3);
            robot.Facing.Should().Be(direction);
        }

        [Fact]
        public void Move_EastDirection()
        {
            var direction = Direction.East;
            robot.Place(2, 2, direction);

            robot.Move();

            robot.X.Should().Be(3);
            robot.Y.Should().Be(2);
            robot.Facing.Should().Be(direction);
        }

        [Fact]
        public void Move_SouthDirection()
        {
            var direction = Direction.South;
            robot.Place(2, 2, direction);

            robot.Move();

            robot.X.Should().Be(2);
            robot.Y.Should().Be(1);
            robot.Facing.Should().Be(direction);
        }

        [Fact]
        public void Move_WestDirection()
        {
            var direction = Direction.West;
            robot.Place(2, 2, direction);

            robot.Move();

            robot.X.Should().Be(1);
            robot.Y.Should().Be(2);
            robot.Facing.Should().Be(direction);
        }

        [Theory]
        [InlineData(4, 4, Direction.North)]
        [InlineData(4, 4, Direction.East)]
        [InlineData(0, 0, Direction.South)]
        [InlineData(0, 0, Direction.West)]
        public void Move_InvalidDirection_RobotNotFallOutsideTheTable(int x, int y, string direction)
        {
            robot.Place(x, y, direction);

            robot.Move();

            robot.X.Should().Be(x);
            robot.Y.Should().Be(y); 
            robot.Facing.Should().Be(direction);
        }

        [Fact]
        public void Move_DiscardCommand_When_RobotNotPlaced()
        {
            robot.Move();

            robot.X.Should().Be(null);
            robot.Y.Should().Be(null);
            robot.Facing.Should().Be(null);
        }



        /* Left Function Tests
         *******************************/

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        public void Left_RotateLeft_90_Degrees(string before, string after)
        {
            robot.Place(1, 1, before);

            robot.Left();

            robot.Facing.Should().Be(after);
        }

        [Fact]
        public void Left_DiscardCommand_When_RobotNotPlaced()
        {
            robot.Left();

            robot.X.Should().Be(null);
            robot.Y.Should().Be(null);
            robot.Facing.Should().Be(null);
        }


        /* Right Function Tests
         *******************************/

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void Right_RotateRight_90_Degrees(string before, string after)
        {
            robot.Place(1, 1, before);

            robot.Right();

            robot.Facing.Should().Be(after);
        }

        [Fact]
        public void Right_DiscardCommand_When_RobotNotPlaced()
        {
            robot.Right();

            robot.X.Should().Be(null);
            robot.Y.Should().Be(null);
            robot.Facing.Should().Be(null);
        }


        /* Right Function Tests
         *******************************/

        [Theory]
        [InlineData(0, 0, Direction.North)]
        [InlineData(1, 2, Direction.East)]
        [InlineData(3, 4, Direction.South)]
        [InlineData(4, 0, Direction.West)]
        public void Report_ReturnRobotPosition(int x, int y, string direction)
        {
            robot.Place(x, y, direction);

            var result = robot.Report();

            result.Should().Be($"{x},{y},{direction}");
        }

        [Fact]
        public void Report_DiscardCommand_When_RobotNotPlaced()
        {
            var result = robot.Report();

            result.Should().Be(null);
        }

    }
}
