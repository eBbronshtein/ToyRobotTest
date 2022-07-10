namespace Robot
{
    public class Table : ISurface
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }

        public Table()
        {}

        public Table(decimal lenght, decimal width)
        {
            Length = lenght;
            Width = width;
        }

        public bool CanMove(ICoordinate to)
        {
            var t = to as Coordinate;

            if(t == null)
            {
                return false;
            }

            if(t.X < 0 || t.Y < 0 || t.X >= Width || t.Y >= Length)
            {
                return false;
            }

            return true;
        }
    }
}
