namespace Robot
{
    public interface IPositionCalculator
    {
        ICoordinate FindNewCoordinate(IPosition position);
        Directions FindNewDirection(Directions oldDirection, MoveTypes moveType);
    }
}
