using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace APIFilter.Filter
{
    public class TimingActionFilter : IActionFilter
    {
        private readonly ILogger<TimingActionFilter> _logger;
        private Stopwatch _stopwatch;

        public TimingActionFilter(ILogger<TimingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            var controllerName = context.Controller.GetType().Name;
            var actionName = context.ActionDescriptor.DisplayName;

            _logger.Log(LogLevel.Information,$"Action {actionName} in {controllerName} took {elapsedMilliseconds} ms to execute.");
        }
    }
}
