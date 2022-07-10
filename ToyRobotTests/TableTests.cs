using Xunit;
using Moq;
using Robot;

namespace ToyRobotTests
{
    public class TableTests
    {
        private const decimal TABLE_SIZE = 5; 

        public TableTests()
        {
        }

        [Fact]
        public void WhenCoordinateNullReturnsFalse()
        {
            ISurface surface = new Table(TABLE_SIZE, TABLE_SIZE);

            var res = surface.CanMove(null);

            Assert.False(res);
        }

        [Fact]
        public void WhenCoordinateOutsideReturnsFalse()
        {
            ISurface surface = new Table(TABLE_SIZE, TABLE_SIZE);

            ICoordinate to = new Coordinate(-1, It.IsAny<decimal>());
            var res = surface.CanMove(to);
            Assert.False(res);

            to = new Coordinate(It.IsAny<decimal>(), -1);
            res = surface.CanMove(to);
            Assert.False(res);

            to = new Coordinate(It.IsAny<decimal>(), TABLE_SIZE + 1);
            res = surface.CanMove(to);
            Assert.False(res);

            to = new Coordinate(TABLE_SIZE + 1, It.IsAny<decimal>());
            res = surface.CanMove(to);
            Assert.False(res);
        }

        [Fact]
        public void WhenCoordinateInsideReturnsFalse()
        {
            ISurface surface = new Table(TABLE_SIZE, TABLE_SIZE);

            ICoordinate to = new Coordinate(It.IsAny<decimal>(), It.IsAny<decimal>());
            var res = surface.CanMove(to);
            Assert.True(res);
        }
    }
}
