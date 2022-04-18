using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using ThreeModels.Models;

namespace ThreeModels.Infrastructure
{
    public class TimeAttribute : ActionFilterAttribute
    {
        private Stopwatch Timer { get; set; }
        private Logger Logger { get; set; }

        public TimeAttribute(Logger logger)
        {
            Logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Timer = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Timer.Stop();
            string message = $"{DateTime.Now}: On executing {context.ActionDescriptor.DisplayName} method " +
                $"left {Timer.ElapsedMilliseconds} miliseconds";

            Logger.WriteLog(message);
        }
    }
}
