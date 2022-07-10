namespace Robot
{
    public class Right : IMove
    {
        private readonly IPositionCalculator positionCalculator;
        private readonly IPosition from;

        public Right(
            IPositionCalculator positionCalculator, 
            IPosition from)
        {
            this.positionCalculator = positionCalculator;
            this.from = from;
        }

        public IPosition Execute()
        {
            if (from != null && positionCalculator != null)
            {
                from.Direction = positionCalculator.FindNewDirection(from.Direction, MoveTypes.Right);
            }

            return from;
        }
    }
}
