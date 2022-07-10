namespace Robot
{
    public class PositionCalculator : IPositionCalculator
    {
        public PositionCalculator()
        {}
        
        public Directions FindNewDirection(Directions oldDirection, MoveTypes moveType)
        {
            if (moveType == MoveTypes.Left)
            {
                if (oldDirection == Directions.North)
                {
                    return Directions.West;
                }
                else if (oldDirection == Directions.West)
                {
                    return Directions.South;
                }
                else if (oldDirection == Directions.South)
                {
                    return Directions.East;
                }
                else
                {
                    return Directions.North;
                }
            }
            else if (moveType == MoveTypes.Right)
            {
                if (oldDirection == Directions.North)
                {
                    return Directions.East;
                }
                else if (oldDirection == Directions.East)
                {
                    return Directions.South;
                }
                else if (oldDirection == Directions.South)
                {
                    return Directions.West;
                }
                else
                {
                    return Directions.North;
                }
            }
            else
            {
                return oldDirection;
            }
        }

        public ICoordinate FindNewCoordinate(IPosition position)
        {
            var coordinate = position?.Coordinate as Coordinate;

            if (coordinate != null)
            {
                switch (position.Direction)
                {
                    case Directions.West:
                        return new Coordinate()
                        {
                            X = coordinate.X - 1,
                            Y = coordinate.Y
                        };
                    case Directions.East:
                        return new Coordinate()
                        {
                            X = coordinate.X + 1,
                            Y = coordinate.Y
                        };
                    case Directions.South:
                        return new Coordinate()
                        {
                            X = coordinate.X,
                            Y = coordinate.Y - 1
                        };
                    case Directions.North:
                    default:
                        return new Coordinate()
                        {
                            X = coordinate.X,
                            Y = coordinate.Y + 1
                        };
                }
            }

            return coordinate;
        }
    }
}
