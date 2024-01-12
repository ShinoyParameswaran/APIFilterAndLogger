using APIFilter.Data;
using APIFilter.Models;

namespace APIFilter.Logger
{
    public class DbLogger : ILogger
    {
        private readonly string categoryName;
        private readonly Func<string, LogLevel, bool> filter;
        private readonly AppDbContext dbContext;

        public DbLogger(string categoryName, Func<string, LogLevel, bool> filter, AppDbContext dbContext)
        {
            this.categoryName = categoryName;
            this.filter = filter;
            this.dbContext = dbContext;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null; // Not used in this example
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return filter == null || filter(categoryName, logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var logEntry = new LogEntry
            {
                Timestamp = DateTime.Now,
                LogLevel = logLevel.ToString(),
                Message = formatter(state, exception)
            };

            
                dbContext.LogEntry.Add(logEntry);
                dbContext.SaveChanges();
              
        }
    }
}
