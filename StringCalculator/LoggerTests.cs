using Moq;
using Xunit;

namespace StringCalculator
{
    public class LoggerTests
    {
        [Fact]
        public void TestLogger()
        {
            var loggerMock = new Mock<ILogger>();
            var calculator = new Calculator(loggerMock.Object ,null);
            calculator.Add("20, 20");
            loggerMock.Verify(r => r.Write("The result is 40"));
        }
    }
}
