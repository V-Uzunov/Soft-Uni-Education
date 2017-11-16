namespace WebServer
{
    using Application;
    using Server;
    using Server.Contracts;
    using Server.Routing;

    public class Startup : IRunnable
    {
        public static void Main()
        {
            new Startup().Run();
        }

        public void Run()
        {
            var mainApplication = new MainApplication();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}
