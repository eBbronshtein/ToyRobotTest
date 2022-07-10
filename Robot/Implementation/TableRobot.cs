namespace Robot
{
    public class TableRobot : IRobot
    {
        private IPosition position = new Position(new Coordinate(), Directions.North);

        public TableRobot()
        {}

        public void Move(IMove move)
        {
            position = move.Execute();
        }

        public IPosition Report()
        {
            return position;
        }
    }
}
