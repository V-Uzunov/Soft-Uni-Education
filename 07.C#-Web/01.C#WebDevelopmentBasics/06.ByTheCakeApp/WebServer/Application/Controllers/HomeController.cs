namespace WebServer.Application.Controllers
{
    using System;
    using System.IO;
    using Infrastructure;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Views;


    public class HomeController : Controller
    {
        // GET /
        public IHttpResponse Index() => this.FileViewResponse(@"Home\index");

        public IHttpResponse About() => this.FileViewResponse(@"Home\about");

        public IHttpResponse SessionTest(IHttpRequest req)
        {
            var session = req.Session;

            const string sessionDateKey = "saved_date";

            if (session.Get(sessionDateKey) == null)
            {
                session.Add(sessionDateKey, DateTime.UtcNow);
            }

            return new ViewResponse(
                HttpStatusCode.Ok,
                new SessionTestView(session.Get<DateTime>(sessionDateKey)));
        }
    }
}