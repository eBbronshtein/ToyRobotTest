namespace Robot
{ 
    public class Move : IMove
    {
        private readonly IPositionCalculator positionCalculator;
        private readonly ISurface surface;
        private readonly IPosition from;

        public Move(
            IPositionCalculator positionCalculator, 
            ISurface surface,
            IPosition from)
        {
            this.positionCalculator = positionCalculator;
            this.surface = surface;
            this.from = from;
        }

        public IPosition Execute()
        {
            if(from != null && positionCalculator != null && surface != null)
            {
                ICoordinate to = positionCalculator.FindNewCoordinate(from);

                if (surface.CanMove(to))
                {
                    return new Position(to, from.Direction);
                }
            }

            return from;
        }
    }
}
