using Robot;

namespace Processor
{
    public interface IInputParser
    {
        bool IsValidInput{ get; set; }
        Commands Command { get; set; }
        IPosition Position { get; set; }
        void Parse(string input);
        Directions ParseDirection(string dir);
    }
}
