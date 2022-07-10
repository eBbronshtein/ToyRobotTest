using Xunit;
using Moq;
using Robot;

namespace ToyRobotTests
{
    public class PlaceTests
    {
        private readonly Mock<IPosition> fromPositionMock;
        private readonly Mock<IPosition> toPositionMock;
        private readonly Mock<ISurface> surfaceMock;

        public PlaceTests()
        {
            fromPositionMock = new Mock<IPosition>();
            toPositionMock = new Mock<IPosition>();
            surfaceMock = new Mock<ISurface>();
        }

        [Fact]
        public void WhenSurfaceNullReturnFrom()
        {
            IMove move = new Place(
                null,
                fromPositionMock.Object,
                toPositionMock.Object);

            var res = move.Execute();

            Assert.Equal(fromPositionMock.Object, res);
        }

        [Fact]
        public void WhenToNullReturnFrom()
        {
            IMove move = new Place(
                surfaceMock.Object,
                fromPositionMock.Object,
                null);

            var res = move.Execute();

            Assert.Equal(fromPositionMock.Object, res);
        }

        [Fact]
        public void WhenToIsNotValidReturnFrom()
        {
            IMove move = new Place(
                surfaceMock.Object,
                fromPositionMock.Object,
                toPositionMock.Object);
            surfaceMock.Setup(s => s.CanMove(It.IsAny<ICoordinate>())).Returns(false);

            var res = move.Execute();

            Assert.Equal(fromPositionMock.Object, res);
        }

        [Fact]
        public void WhenToIsValidReturnTo()
        {
            IMove move = new Place(
                surfaceMock.Object,
                fromPositionMock.Object,
                toPositionMock.Object);
            surfaceMock.Setup(s => s.CanMove(It.IsAny<ICoordinate>())).Returns(true);

            var res = move.Execute();

            Assert.Equal(toPositionMock.Object, res);
        }
    }
}
