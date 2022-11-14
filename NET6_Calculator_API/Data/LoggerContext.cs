using Microsoft.EntityFrameworkCore;
using NET6_Calculator_API.Data.Models;

namespace NET6_Calculator_API.Data
{
    public class LoggerContext : DbContext
    {
        public virtual DbSet<Log> Logs { get; set; }

        public LoggerContext(DbContextOptions<LoggerContext> options) : base(options)
        {

        }
    }
}
