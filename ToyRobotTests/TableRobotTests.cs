using Xunit;
using Moq;
using Robot;

namespace ToyRobotTests
{
    public class TableRobotTests
    {
        public TableRobotTests()
        {
        }

        [Fact]
        public void WhenCoordinateNullReturnsFalse()
        {
            IRobot robot = new TableRobot();
            Mock<IMove> moveMock = new Mock<IMove>();
            Mock<IPosition> positionMock = new Mock<IPosition>();

            moveMock.Setup(s => s.Execute()).Returns(positionMock.Object);

            robot.Move(moveMock.Object);

            Assert.Equal(positionMock.Object, robot.Report());
        }
    }
}
