using Xunit;
using Moq;
using Robot;

namespace ToyRobotTests
{
    public class LeftTests
    {
        private readonly Mock<IPosition> fromPositionMock;
        private readonly Mock<IPositionCalculator> positionCalculatorMock;

        public LeftTests()
        {
            fromPositionMock = new Mock<IPosition>();

            positionCalculatorMock = new Mock<IPositionCalculator>();
        }

        [Fact]
        public void WhenPositionCalcNullReturnsFrom()
        {
            IMove move = new Left(
                null,
                fromPositionMock.Object);

            var res = move.Execute();

            Assert.Equal(fromPositionMock.Object, res);
        }

        [Fact]
        public void TurnLeftFromNorth()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.North);
            IMove move = new Left(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.North, MoveTypes.Left))
                                  .Returns(Directions.West);

            var res = move.Execute();

            Assert.Equal(Directions.West, res.Direction);
        }

        [Fact]
        public void TurnLeftFromEast()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.East);
            IMove move = new Left(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.East, MoveTypes.Left))
                                  .Returns(Directions.North);

            var res = move.Execute();

            Assert.Equal(Directions.North, res.Direction);
        }

        [Fact]
        public void TurnLeftFromWest()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.West);
            IMove move = new Left(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.West, MoveTypes.Left))
                                  .Returns(Directions.South);

            var res = move.Execute();

            Assert.Equal(Directions.South, res.Direction);
        }

        [Fact]
        public void TurnLeftFromSouth()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.South);
            IMove move = new Left(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.South, MoveTypes.Left))
                                  .Returns(Directions.East);

            var res = move.Execute();

            Assert.Equal(Directions.East, res.Direction);
        }
    }
}
