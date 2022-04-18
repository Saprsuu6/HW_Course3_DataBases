using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using ThreeModels.Models;

namespace ThreeModels.Infrastructure
{
    public class ClientsAttribute : ActionFilterAttribute
    {
        public static uint counter = 0;

        private Stopwatch Timer { get; set; }
        private Logger Logger { get; set; }

        public ClientsAttribute(Logger logger)
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

            string result = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            string message = $"{DateTime.Now}: Employer {result} ({counter}) visited " +
                $"site for {Timer.ElapsedMilliseconds} miliseconds";

            Logger.WriteLog(message);
        }
    }
}
