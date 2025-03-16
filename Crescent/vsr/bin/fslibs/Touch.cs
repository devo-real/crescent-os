using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VNU.FsCMDS
{
    internal class Touch
    {
        public static void Init(string file)
        {
            string filePath = file.Substring(6);

            try
            {
                File.Create(filePath);
                if (filePath.EndsWith(".txt"))
                {
                    Console.WriteLine("New raw text file made in current directory");
                }
                else if (filePath.EndsWith(".asm") || filePath.EndsWith(".s"))
                {
                    Console.WriteLine("New assembly source file made in current directory");
                }
                else if (filePath.EndsWith(".cs"))
                {
                    Console.WriteLine("New C# source file made in current directory");
                }
                else if (filePath.EndsWith(".c"))
                {
                    Console.WriteLine("New C source file made in current directory");
                }
                else if (filePath.EndsWith(".h"))
                {
                    Console.WriteLine("New C header file made in current directory");
                }
                else if (filePath.EndsWith(".bf"))
                {
                    Console.WriteLine("New brainf*** file made in current directory");
                }
                else if (filePath.EndsWith("Makefile"))
                {
                    Console.WriteLine("New GNU Makefile made in current directory");
                }
                else if (filePath.EndsWith("VNUfile"))
                {
                    Console.WriteLine("New VNUfile made in current directory");
                }
                else
                {
                    Console.WriteLine("New unknown file type made in current directory");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
