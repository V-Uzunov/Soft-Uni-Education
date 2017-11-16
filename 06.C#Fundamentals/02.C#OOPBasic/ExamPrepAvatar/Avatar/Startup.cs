public class Startup
{
    public static void Main()
    {
        IWriter writer = new WriteLine();
        IReader reader = new ReadLine();
        INationsBuilder builder = new NationsBuilder();
        IEngine engine = new Engine(builder, writer, reader);
        engine.Run();
    }
}
