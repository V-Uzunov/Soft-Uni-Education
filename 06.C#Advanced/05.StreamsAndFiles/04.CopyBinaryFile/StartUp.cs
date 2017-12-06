namespace _04.CopyBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var originalFile = new FileStream(@"..\..\sheep.jpg", FileMode.Open))
            {
                using (var copyFile = new FileStream(@"..\..\newSheep.jpg", FileMode.Create))
                {
                    while (originalFile.Position < originalFile.Length)
                    {
                        copyFile.WriteByte((byte)(originalFile.ReadByte()));
                    }
                }
            }
        }
    }
}
