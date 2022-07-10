using Robot;
using Xunit;
using Moq;

namespace ToyRobotTests
{
    public class CoordinateTests
    {
        [Fact]
        public void WhenSeccondCoordinateIsNullAddReturnsFirstCoordinate()
        {
            ICoordinate c1 = new Coordinate(0, 0);
            ICoordinate c2 = null;

            var res = c1.Add(c2);

            Assert.Equal(res, c1);
        }

        [Fact]
        public void WhenSeccondCoordinateIsNotNullAddReturnsACoordinate()
        {
            ICoordinate c1 = new Coordinate(It.IsAny<decimal>(), It.IsAny<decimal>());
            ICoordinate c2 = new Coordinate(It.IsAny<decimal>(), It.IsAny<decimal>());

            var res = c1.Add(c2);

            Assert.NotNull(res);
        }
    }
}
