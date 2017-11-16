namespace WebServer.Server.Http.Response
{
    using System;
    using Common;
    using Enums;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}
