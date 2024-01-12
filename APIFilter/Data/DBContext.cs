using System.Collections.Generic;
using APIFilter.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFilter.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<LogEntry> LogEntry { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
