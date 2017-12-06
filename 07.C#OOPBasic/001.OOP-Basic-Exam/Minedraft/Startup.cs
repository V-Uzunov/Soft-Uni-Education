public class Startup
{
    public static void Main()
    {
        IReader reader = new Reader();
        IWriter writer = new Writer();
        IDraftManager draftManager = new DraftManager();

        IEngine engine = new Engine(reader, writer, draftManager);
        engine.Run();
    }
}