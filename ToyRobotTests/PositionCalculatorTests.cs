using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Robot;

namespace ToyRobotTests
{
    public class PositionCalculatorTests
    {
        private readonly Mock<IPosition> positionMock;
        private readonly Mock<ICoordinate> coordinateMock;

        public PositionCalculatorTests()
        {
            positionMock = new Mock<IPosition>();
            coordinateMock = new Mock<ICoordinate>();
        }

        [Fact]
        public void FromNorthLeftTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.North, MoveTypes.Left);

            Assert.Equal(Directions.West, res);
        }

        [Fact]
        public void FromWestLeftTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.West, MoveTypes.Left);

            Assert.Equal(Directions.South, res);
        }

        [Fact]
        public void FromSouthLeftTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.South, MoveTypes.Left);

            Assert.Equal(Directions.East, res);
        }

        [Fact]
        public void FromEastLeftTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.East, MoveTypes.Left);

            Assert.Equal(Directions.North, res);
        }

        [Fact]
        public void FromNorthRightTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.North, MoveTypes.Right);

            Assert.Equal(Directions.East, res);
        }

        [Fact]
        public void FromEastRightTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.East, MoveTypes.Right);

            Assert.Equal(Directions.South, res);
        }

        [Fact]
        public void FromSouthRightTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.South, MoveTypes.Right);

            Assert.Equal(Directions.West, res);
        }

        [Fact]
        public void FromWestRightTest()
        {
            IPositionCalculator pc = new PositionCalculator();

            var res = pc.FindNewDirection(Directions.West, MoveTypes.Right);

            Assert.Equal(Directions.North, res);
        }

        [Fact]
        public void FindNewPositionNorth()
        {
            IPositionCalculator pc = new PositionCalculator();
            IPosition position = new Position(new Coordinate(0, 0), Directions.North);

            var res = pc.FindNewCoordinate(position);

            Assert.Equal(1, (res as Coordinate).Y);
            Assert.Equal(0, (res as Coordinate).X);
        }

        [Fact]
        public void FindNewPositionSouth()
        {
            IPositionCalculator pc = new PositionCalculator();
            IPosition position = new Position(new Coordinate(0, 0), Directions.South);

            var res = pc.FindNewCoordinate(position);

            Assert.Equal(-1, (res as Coordinate).Y);
            Assert.Equal(0, (res as Coordinate).X);
        }

        [Fact]
        public void FindNewPositionWest()
        {
            IPositionCalculator pc = new PositionCalculator();
            IPosition position = new Position(new Coordinate(0, 0), Directions.West);

            var res = pc.FindNewCoordinate(position);

            Assert.Equal(0, (res as Coordinate).Y);
            Assert.Equal(-1, (res as Coordinate).X);
        }

        [Fact]
        public void FindNewPositionEast()
        {
            IPositionCalculator pc = new PositionCalculator();
            IPosition position = new Position(new Coordinate(0, 0), Directions.East);

            var res = pc.FindNewCoordinate(position);

            Assert.Equal(0, (res as Coordinate).Y);
            Assert.Equal(1, (res as Coordinate).X);
        }
    }
}
