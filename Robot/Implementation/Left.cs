namespace Robot
{
    public class Left : IMove
    {
        private readonly IPositionCalculator positionCalculator;
        private readonly IPosition from;

        public Left(
            IPositionCalculator positionCalculator, 
            IPosition from)
        {
            this.positionCalculator = positionCalculator;
            this.from = from;
        }

        public IPosition Execute()
        {
            if(from != null && positionCalculator != null)
            {
                from.Direction = positionCalculator.FindNewDirection(from.Direction, MoveTypes.Left);
            }

            return from;
        }
    }
}
