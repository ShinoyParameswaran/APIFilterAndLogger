﻿namespace APIFilter.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
    }

}
