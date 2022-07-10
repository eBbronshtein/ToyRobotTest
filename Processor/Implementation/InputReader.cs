using System;

namespace Processor
{
    public class InputReader : IInputReader
    {
        public InputReader()
        {}

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
