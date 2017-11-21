namespace CameraBazaar.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Diagnostics;
    using System.IO;
    public class TimeMeasuresAttribute : ActionFilterAttribute
    {
        private Stopwatch stopwatch;


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();

        }

        public TimeMeasuresAttribute()
        {
            this.stopwatch = new Stopwatch();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            this.stopwatch.Stop();

            using (var writer = new StreamWriter("action-times.txt", true))
            {
                var dateTime = DateTime.UtcNow;
                var controller = context.Controller.GetType().Name;
                var action = context.RouteData.Values["action"];
                var elapsedTime = stopwatch.Elapsed;

                var logMessage = $"{dateTime} - {controller}.{action} ---> {elapsedTime}";

                writer.WriteLine(logMessage);
            }
        }
    }
}
