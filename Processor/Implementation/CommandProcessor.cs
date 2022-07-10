using Robot;

namespace Processor
{
    public class CommandProcessor : ICommandProcessor
    {
        IPositionCalculator positionCalculator;
        ISurface table;
        IInputParser inputParser; 
        IOutputWriter outputWriter;
        IInputReader inputReader;
        IRobot robot;

        public CommandProcessor(
            IPositionCalculator positionCalculator,
            ISurface table,
            IInputParser inputParser,
            IOutputWriter outputWriter,
            IInputReader inputReader,
            IRobot robot)
        {
            this.positionCalculator = positionCalculator;
            this.table = table;
            this.inputParser = inputParser;
            this.outputWriter = outputWriter;
            this.inputReader = inputReader;
            this.robot = robot;
        }

        public void Process()
        {
            if (robot != null && inputParser != null && inputReader != null)
            {
                while (!inputParser.IsValidInput || inputParser.Command != Commands.Place)
                {
                    outputWriter.Print("First command must be PLACE X, Y, Direction");
                    ReadInput();

                    if (inputParser.Command == Commands.Exit)
                    {
                        return;
                    }
                }

                IMove next;

                while (inputParser.Command != Commands.Exit)
                {
                    if (inputParser.IsValidInput)
                    {
                        switch (inputParser.Command)
                        {
                            case Commands.Move:
                                next = new Move(positionCalculator, table, robot.Report());
                                robot.Move(next);
                                break;
                            case Commands.Left:
                                next = new Left(positionCalculator, robot.Report());
                                robot.Move(next);
                                break;
                            case Commands.Right:
                                next = new Right(positionCalculator, robot.Report());
                                robot.Move(next);
                                break;
                            case Commands.Place:
                                next = new Place(table, robot.Report(), inputParser.Position);
                                robot.Move(next);
                                break;
                            case Commands.Report:
                                IPosition position = robot.Report();
                                if (position != null && position.Coordinate != null)
                                {
                                    var coordinate = position.Coordinate as Coordinate;
                                    outputWriter?.Print($"Curent position is: X = {coordinate.X} Y = {coordinate.Y} Direction = {position.Direction.ToString()}");
                                }
                                else
                                {
                                    outputWriter?.Print("Position is undefined.");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        outputWriter?.Print("Invalid command.");
                    }

                    ReadInput();
                }
            }
        }

        private void ReadInput()
        {
            string nextCommand = inputReader.Read();
            inputParser.Parse(nextCommand);
        }
    }
}
