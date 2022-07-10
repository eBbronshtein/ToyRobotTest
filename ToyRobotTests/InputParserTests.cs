using Robot;
using Xunit;
using Moq;
using Processor;
using System;

namespace ToyRobotTests
{
    public class InputParserTests
    {
        [Fact]
        public void InputNullIsNotValid()
        {
            IInputParser parser = new InputParser();

            parser.Parse(null);

            Assert.False(parser.IsValidInput);
        }

        [Fact]
        public void InputEmptyIsNotValid()
        {
            IInputParser parser = new InputParser();

            parser.Parse(string.Empty);

            Assert.False(parser.IsValidInput);
        }

        [Fact]
        public void InputIsNotValid()
        {
            IInputParser parser = new InputParser();

            parser.Parse(It.IsAny<string>());

            Assert.False(parser.IsValidInput);
        }

        [Fact]
        public void MoveIsValid()
        {
            IInputParser parser = new InputParser();

            parser.Parse(Commands.Move.ToString());

            Assert.True(parser.IsValidInput);
            Assert.Equal(Commands.Move, parser.Command);
        }

        [Fact]
        public void LeftIsValid()
        {
            IInputParser parser = new InputParser();

            parser.Parse(Commands.Left.ToString());

            Assert.True(parser.IsValidInput);
            Assert.Equal(Commands.Left, parser.Command);
        }

        [Fact]
        public void RightIsValid()
        {
            IInputParser parser = new InputParser();

            parser.Parse(Commands.Right.ToString());

            Assert.True(parser.IsValidInput);
            Assert.Equal(Commands.Right, parser.Command);
        }

        [Fact]
        public void ValidPlaceIsValid()
        {
            IInputParser parser = new InputParser();
            Directions direction = It.IsAny<Directions>();
            decimal x = It.IsAny<decimal>();
            decimal y = It.IsAny<decimal>();
            var separators = new char[] { ' ', '\t', ',' };
            Random r = new Random();

            parser.Parse($"{Commands.Place} {x}{separators[r.Next(0, 2)]}{y}{separators[r.Next(0, 2)]}{direction}");

            Assert.True(parser.IsValidInput);
            Assert.Equal(Commands.Place, parser.Command);
            Assert.Equal(direction, parser.Position.Direction);
            Assert.Equal(x, (parser.Position.Coordinate as Coordinate).X);
            Assert.Equal(y, (parser.Position.Coordinate as Coordinate).Y);
        }
    }
}
