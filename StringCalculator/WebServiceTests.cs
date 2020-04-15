using Moq;
using Xunit;

namespace StringCalculator
{
    public class  WebServiceTests
    {

        [Fact]
        public void WebServiceIsCalled()
        {
            var stubbedLogger = new Mock<ILogger>();
            stubbedLogger.Setup(r => r.Write(It.IsAny<string>())).Throws(new LogException("exception"));
            var webServerMock = new Mock<IWebService>();
            var calculator = new Calculator(stubbedLogger.Object, webServerMock.Object);
            int result = calculator.Add("1,2");
            webServerMock.Verify(r => r.LogFailure("Failed"));
        }

    }
}
