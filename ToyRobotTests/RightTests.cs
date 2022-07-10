using Xunit;
using Moq;
using Robot;

namespace ToyRobotTests
{
    public class RightTests
    {
        private readonly Mock<IPosition> fromPositionMock;
        private readonly Mock<IPositionCalculator> positionCalculatorMock;

        public RightTests()
        {
            fromPositionMock = new Mock<IPosition>();

            positionCalculatorMock = new Mock<IPositionCalculator>();
        }

        [Fact]
        public void WhenPositionCalcNullReturnsFrom()
        {
            IMove move = new Right(
                null,
                fromPositionMock.Object);

            var res = move.Execute();

            Assert.Equal(fromPositionMock.Object, res);
        }

        [Fact]
        public void TurnRightFromNorth()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.North);
            IMove move = new Right(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.North, MoveTypes.Right))
                                  .Returns(Directions.East);

            var res = move.Execute();

            Assert.Equal(Directions.East, res.Direction);
        }

        [Fact]
        public void TurnRightFromEast()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.East);
            IMove move = new Right(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.East, MoveTypes.Right))
                                  .Returns(Directions.South);

            var res = move.Execute();

            Assert.Equal(Directions.South, res.Direction);
        }

        [Fact]
        public void TurnRightFromWest()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.West);
            IMove move = new Right(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.West, MoveTypes.Right))
                                  .Returns(Directions.North);

            var res = move.Execute();

            Assert.Equal(Directions.North, res.Direction);
        }

        [Fact]
        public void TurnRightFromSouth()
        {
            IPosition position = new Position(new Coordinate(0, 0), Directions.South);
            IMove move = new Right(
                positionCalculatorMock.Object,
                position);
            positionCalculatorMock.Setup(s => s.FindNewDirection(Directions.South, MoveTypes.Right))
                                  .Returns(Directions.West);

            var res = move.Execute();

            Assert.Equal(Directions.West, res.Direction);
        }
    }
}
