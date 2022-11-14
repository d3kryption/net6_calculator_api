using NET6_Calculator_API.Data.Models;

namespace NET6_Calculator_API.Data.Interfaces
{
    public interface ILoggerRepository
    {
        Task<bool> Post(float firstnumber, string arithmeticoperator, float secondnumber, float? result, bool successfulresult);

        Task<IEnumerable<Log>> GetLogs();

        Task<bool> ClearLogs();
    }
}
