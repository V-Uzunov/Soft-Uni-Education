namespace WebServer.Application.Controllers
{
    using System;
    using Server.Enums;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Views;


    public class HomeController
    {
        // GET /
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.Ok, new IndexView());

            response.Cookies.Add(new HttpCookie("lang", "en"));

            return response;
        }

        // Get /testsession
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
