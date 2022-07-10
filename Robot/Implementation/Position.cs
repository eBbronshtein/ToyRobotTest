namespace Robot
{
    public class Position : IPosition
    {
        public Directions Direction { get; set; } 
        public ICoordinate Coordinate { get; set; }

        public Position(ICoordinate coordinate, Directions direction)
        {
            Direction = direction;
            Coordinate = coordinate;
        }
    }
}
