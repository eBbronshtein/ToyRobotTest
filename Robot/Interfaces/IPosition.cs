namespace Robot
{
    public interface IPosition
    {
        Directions Direction { get; set; }
        ICoordinate Coordinate { get; set; }
    }
}
