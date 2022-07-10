using Xunit;
using Moq;
using Robot;

namespace ToyRobotTests
{
    public class MoveTests
    {
        private readonly Mock<IPosition> fromPositionMock;
        private readonly Mock<IPositionCalculator> positionCalculatorMock;
        private readonly Mock<ISurface> surfaceMock;

        public MoveTests()
        {
            fromPositionMock = new Mock<IPosition>();

            positionCalculatorMock = new Mock<IPositionCalculator>();
            surfaceMock = new Mock<ISurface>();
        }

        [Fact]
        public void WhenFromNullAddReturnsNull()
        {
            IMove move = new Move(
                positionCalculatorMock.Object,
                surfaceMock.Object,
                null);

            var res = move.Execute();

            Assert.Null(res);
        }

        [Fact]
        public void WhenSurfaceNullAddReturnsFrom()
        {
            IMove move = new Move(
                positionCalculatorMock.Object,
                surfaceMock.Object,
                fromPositionMock.Object);
            fromPositionMock.Setup(s => s.Direction).Returns(It.IsAny<Directions>());
            fromPositionMock.Setup(s => s.Coordinate).Returns(It.IsAny<ICoordinate>());

            var res = move.Execute();

            Assert.Equal(fromPositionMock.Object, res);
        }

        [Fact]
        public void WhenCannotMoveToNewPositionReturnsFrom()
        {
            IMove move = new Move(
                positionCalculatorMock.Object,
                surfaceMock.Object,
                fromPositionMock.Object);
            fromPositionMock.Setup(s => s.Direction).Returns(It.IsAny<Directions>());
            fromPositionMock.Setup(s => s.Coordinate).Returns(It.IsAny<ICoordinate>());
            surfaceMock.Setup(s => s.CanMove(It.IsAny<ICoordinate>())).Returns(false);

            var res = move.Execute();

            Assert.Equal(fromPositionMock.Object, res);
        }

        [Fact]
        public void WhenCanMoveToNewPositionReturnsNewPosition()
        {
            IMove move = new Move(
                positionCalculatorMock.Object,
                surfaceMock.Object,
                fromPositionMock.Object);
            fromPositionMock.Setup(s => s.Direction).Returns(It.IsAny<Directions>());
            fromPositionMock.Setup(s => s.Coordinate).Returns(It.IsAny<ICoordinate>());
            surfaceMock.Setup(s => s.CanMove(It.IsAny<ICoordinate>())).Returns(true);

            var res = move.Execute();

            Assert.NotNull(res);
            Assert.Equal(fromPositionMock.Object.Direction, res.Direction);
        }
    }
}
