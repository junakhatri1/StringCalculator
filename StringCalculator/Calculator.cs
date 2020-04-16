
using System;


namespace StringCalculator
{
    public class Calculator
    {
        private readonly ILogger Logger;
        private readonly IWebService WebService;

        public Calculator(ILogger logger, IWebService webService)
        {
            Logger = logger;
            WebService = webService;

        }

        public int Add(string numbers)
        {
            if(numbers == "")
            {
                return 0;
            }
            string[] numbersInList = numbers.Split(',');
            int result = 0;
            for(int i=0; i < numbersInList.Length; i++)
            {
                result += Int32.Parse(numbersInList[i]);
            }
            try
            {
                Logger.Write($"The result of add method is {result}");
            }
            catch(LogException ex)
            {
                WebService.LogFailure("Logging failed");
            }
           
            return result;
        }
    }
}