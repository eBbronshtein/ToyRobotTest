using Processor;
using Robot;

namespace ToyRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPositionCalculator positionCalculator = new PositionCalculator();
            ISurface table = new Table() { Length = 6, Width = 6 };
            IInputParser inputParser = new InputParser();
            IOutputWriter outputWriter = new OutputWriter();
            IInputReader inputReader = new InputReader();
            IRobot robot = new TableRobot();

            ICommandProcessor processor = new CommandProcessor(
                positionCalculator,
                table,
                inputParser,
                outputWriter,
                inputReader,
                robot);

            processor.Process();
        }
    }
}
