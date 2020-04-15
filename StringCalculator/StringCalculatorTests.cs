using Moq;
using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTests
    {
        private readonly Mock<ILogger> stubbedLogger = new Mock<ILogger>();

        [Fact]
        public void EmptyStringReturnsZero()
        {
            var calculator = new Calculator(stubbedLogger.Object, null);
            int answer = calculator.Add("");
            Assert.Equal(0, answer);
        }

        [Fact]
        public void AddTakesEmptyString()
        {
            var calculator = new Calculator(stubbedLogger.Object, null);
            string input = "";
            int result = calculator.Add(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddTakesOneNumber()
        {
            var calculator = new Calculator(stubbedLogger.Object, null);
            string input = "1";
            int result = calculator.Add(input);
            Assert.Equal(1, result);
        }


        [Theory]
        [InlineData("10, 10", 20)]
        [InlineData("1, -1", 0)]
        public void AddTakesTwoNumbers(string numbers, int expected)
        {
            var calculator = new Calculator(stubbedLogger.Object, null);
            int result = calculator.Add(numbers);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("2, 4, 6, 8, 10", 30)]
        [InlineData("10, 10, -1, 11, 10, 8, 2", 50)]
        public void AddTakesMoreThanTwoNumbers(string numbers, int expected)
        {
            var calculator = new Calculator(stubbedLogger.Object, null);
            int result = calculator.Add(numbers);
            Assert.Equal(expected, result);
        }
    }
}
