using Microsoft.EntityFrameworkCore;
using NET6_Calculator_API.Data.Interfaces;
using NET6_Calculator_API.Data.Models;

namespace NET6_Calculator_API.Data.Repositories
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly LoggerContext _loggerContext;

        public LoggerRepository(LoggerContext loggerContext)
        {
            _loggerContext = loggerContext;
        }

        public async Task<bool> ClearLogs()
        {
            try
            {
                await _loggerContext.Logs.ExecuteDeleteAsync();

                return true;
            }
            catch
            {
                // TODO - Insert error capture
                return false;
            }
        }

        public async Task<IEnumerable<Log>> GetLogs()
        {
            var results = new List<Log>();

            try
            {
                results = await _loggerContext.Logs.ToListAsync();

                return results;
            }
            catch
            {
                // TODO - Insert error capture
                return results;
            }
        }

        public async Task<bool> Post(float firstnumber, string arithmeticoperator, float secondnumber, float? result, bool successfulresult)
        {
            try
            {
                var calculation = new Log
                {
                    FirstNumber = firstnumber,
                    ArithmeticOperator = arithmeticoperator,
                    SecondNumber = secondnumber,
                    Result = result,
                    SuccessfulResult = successfulresult
                };

                _loggerContext.Logs.Add(calculation);
                await _loggerContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                // TODO - Insert error capture
                return false;
            }
        }
    }
}
