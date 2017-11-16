public class StartUp
{
    public static void Main()
    {
        IItemFactory itemFactory = new ItemFactory();
        InventoryFactory inventoryFactory = new InventoryFactory();
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IHeroManager heroManager = new HeroManager(itemFactory, inventoryFactory);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(heroManager);

        Engine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}