using Robot;
using System;

namespace Processor
{
    public class OutputWriter : IOutputWriter
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
