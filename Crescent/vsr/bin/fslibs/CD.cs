using Cosmos.System.FileSystem.Listing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.FsCMDS
{
    internal class CD
    {
        public static string CurrentDirectory = @"0:\";

        public static void ChangeDirectory(string newPath)
        {
            string fullPath = Path.Combine(CurrentDirectory, newPath);

            if (Directory.Exists(fullPath))
            {
                CurrentDirectory = fullPath;
            }
            else if (File.Exists(newPath) && !Directory.Exists(newPath))
            {
                Console.WriteLine($"cd: {newPath} exists, but is not a directory\n" +
                    $"cd: If you would like to edit the file, open it in MIV.");
            }
            else if (CurrentDirectory != @"0:\" && newPath.Length == 1)
            {
                GETBACK();
            }
            else if (newPath == "..")
            {
                if (CurrentDirectory == @"0:\")
                {
                    Console.WriteLine("Already at the root directory.");
                }
                else
                {
                    DirectoryInfo childDir = new DirectoryInfo(CurrentDirectory);
                    CurrentDirectory = childDir.Parent.FullName;
                }
            }
            else
            {
                Console.WriteLine("Directory not found: " + newPath);
            }
        }

        public static void GETBACK()
        {
            CurrentDirectory = @"0:\";
        }
    }
}
