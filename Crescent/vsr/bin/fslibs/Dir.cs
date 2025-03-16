using Crescent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.Commands
{
    internal class GDir
    {
        // Get space, total and free
        public static float space = Kernel.fileSystem.GetTotalSize(Kernel.ROOTDISK) / (1024 ^ 3);
        public static float freeSpace = Kernel.fileSystem.GetAvailableFreeSpace(Kernel.ROOTDISK) / (1024 ^ 3);

        public static void Dir()
        {
            string[] filePaths = Directory.GetFiles(FsCMDS.CD.CurrentDirectory);
            var drive = new DriveInfo("0");
            Console.WriteLine("Volume in drive 0 is " + $"{drive.VolumeLabel}");
            Console.WriteLine("Directory of " + FsCMDS.CD.CurrentDirectory);
            Console.WriteLine("\n");
            for (int i = 0; i < filePaths.Length; ++i)
            {
                string path = filePaths[i];
                Console.WriteLine(System.IO.Path.GetFileName(path));
            }
            foreach (var d in System.IO.Directory.GetDirectories(FsCMDS.CD.CurrentDirectory))
            {
                var dir = new DirectoryInfo(d);
                var dirName = dir.Name;
                Console.WriteLine(dirName + "       <DIRECTORY>");
                
            }
            Console.WriteLine("\n");
            Console.WriteLine($"{space}" + " megabytes on full disk");
            Console.WriteLine($"{freeSpace}" + " megabytes free on full disk");
        }
    }
}