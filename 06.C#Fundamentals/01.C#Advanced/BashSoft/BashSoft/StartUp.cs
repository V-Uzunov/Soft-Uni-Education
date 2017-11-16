namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);
            //IOManager.CreateDirectoryInCurrentFolder("veso");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");
            IOManager.ChangeCurrentDirectoryRelative("..");

        }
    }
}