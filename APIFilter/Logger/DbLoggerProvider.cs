using APIFilter.Data;

namespace APIFilter.Logger
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly AppDbContext dbContext;

        public DbLoggerProvider(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(categoryName, null, dbContext);
        }

        public void Dispose()
        {
            // Cleanup logic, if any
        }
    }
}
