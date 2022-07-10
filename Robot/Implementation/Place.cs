namespace Robot
{
    public class Place : IMove
    {
        private readonly ISurface surface;
        private readonly IPosition from;
        private readonly IPosition to;

        public Place(
            ISurface surface,
            IPosition from,
            IPosition to)
        {
            this.from = from;
            this.to = to;
            this.surface = surface;
        }

        public IPosition Execute()
        {
            if(surface != null && to != null && surface.CanMove(to.Coordinate))
            {
                return to;
            }
            else
            {
                return from;
            }
        }
    }
}
