using Robot;
using System;
using System.Linq;

namespace Processor
{
    public class InputParser : IInputParser
    {
        private const string MOVE = "move";
        private const string LEFT = "left";
        private const string RIGHT = "right";
        private const string REPORT = "report";
        private const string PLACE = "place";
        private const string EXIT = "exit";
        private const int PLACE_PARAMS_NUM = 4;

        public bool IsValidInput { get; set; }
        public Commands Command { get; set; }
        public IPosition Position { get; set; }

        public void Parse(string input)
        {
            var parsedInput = input?.Trim().ToLower();

            if(String.IsNullOrEmpty(parsedInput))
            {
                IsValidInput = false;
                return;
            }

            if(parsedInput == EXIT)
            {
                IsValidInput = true;
                Command = Commands.Exit;
                Position = null;

                return;
            }

            if (parsedInput == MOVE)
            {
                IsValidInput = true;
                Command = Commands.Move;
                Position = null;

                return;
            }

            if(parsedInput == LEFT)
            {
                IsValidInput = true;
                Command = Commands.Left;
                Position = null;

                return;
            }

            if (parsedInput == RIGHT)
            {
                IsValidInput = true;
                Command = Commands.Right;
                Position = null;

                return;
            }

            if (parsedInput == REPORT)
            {
                IsValidInput = true;
                Command = Commands.Report;
                Position = null;

                return;
            }

            var parameters = parsedInput?.Split(new char[] { ' ', '\t', ',' })
                                         .ToList()
                                         .Where(w => w.Trim() != String.Empty);
            ICoordinate coordinate = new Coordinate();
            decimal x;
            decimal y;

            if (parameters.Contains(PLACE) &&
                parameters.Count() == PLACE_PARAMS_NUM &&
                Decimal.TryParse(parameters.ElementAt(1), out x) &&
                Decimal.TryParse(parameters.ElementAt(2), out y) &&
                (parameters.ElementAt(3).ToLower() == Directions.West.ToString().ToLower() ||
                 parameters.ElementAt(3).ToLower() == Directions.East.ToString().ToLower() ||
                 parameters.ElementAt(3).ToLower() == Directions.North.ToString().ToLower() ||
                 parameters.ElementAt(3).ToLower() == Directions.South.ToString().ToLower()))
            { 
                IsValidInput = true;
                coordinate = new Coordinate() { X = x, Y = y };
                Command = Commands.Place;
                Directions dir = ParseDirection(parameters.ElementAt(3).ToLower());
                Position = new Position(coordinate, dir);

                return;
            }

            IsValidInput = false;
        }

        public Directions ParseDirection(string dir)
        {
            if(dir == Directions.West.ToString().ToLower())
            {
                return Directions.West;
            }
            if (dir == Directions.East.ToString().ToLower())
            {
                return Directions.East;
            }
            if (dir == Directions.North.ToString().ToLower())
            {
                return Directions.North;
            }
            if (dir == Directions.South.ToString().ToLower())
            {
                return Directions.South;
            }

            return Directions.North;
        }
    }
}
