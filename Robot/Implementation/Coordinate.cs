namespace Robot
{ 
    public class Coordinate : ICoordinate
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public Coordinate()
        {}

        public Coordinate(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public ICoordinate Add(ICoordinate c)
        {
            if(c == null)
              return this;

            return new Coordinate() 
            { 
                X = X + (c as Coordinate).X, 
                Y = Y + (c as Coordinate).Y 
            };
        }
    }
}
