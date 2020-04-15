using System;

namespace StringCalculator
{
    public class LogException: ApplicationException
    {
        public LogException(string message): base(message)
        {

        }
    }
}
