using Crescent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNU.Commands;
using VNU.FsCMDS;
using VNU.MiscCMDS;

namespace VNU.root
{
    internal class CommandPrompt
    {
        static void WriteSysInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Kernel.ROOTUSERNAME);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Kernel.PCNAME);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("~" + CD.CurrentDirectory);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" > ");
        }

        public static void CMD()
        {
            WriteSysInfo();
            var input = Console.ReadLine();
            if (input == "dir")
            {
                GDir.Dir();
            }
            else if (input.StartsWith("echo ")) { Echo.Init(input); }
            else if (input == "slots") { Crescent.Fun.Slots.Play(); }
            else if (input.StartsWith("odd-or-even ")) { Crescent.Fun.IsEven.Init(Convert.ToInt32(input.Substring(12))); }
            else if (input.StartsWith("cd ")) { FsCMDS.CD.ChangeDirectory(input.Substring(3)); }
            else if (input.StartsWith("rd ")) { FsCMDS.RD.Init(input); }
            else if (input.StartsWith("md ")) { FsCMDS.MD.Init(input); }
            else if (input.StartsWith("rdrf ")) { FsCMDS.RDRF.Init(input); }
            else if (input.StartsWith("rdf ")) { FsCMDS.RDF.Init(input); }
            else if (input.StartsWith("touch ")) { FsCMDS.Touch.Init(input); }
            else if (input.StartsWith("fib ")) { Crescent.Fun.Fib.Init(input); }
            else if (input == "miv")
            {
                try
                {
                    MIV.MIV.StartMIV();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (input.StartsWith("lsct ")) { LSCT.Run(input); }
            else if (input == "shutdown") { PowerCMDS.Shutdown.Init(); }
            else if (input == "reboot") { PowerCMDS.Reboot.Init(); }
            else if (input == "clear") { Console.Clear(); }
            else if (input == "scary") { Console.WriteLine("/// FAKE SCARY ///");
                Security.ScaryOperation.RaiseScaryOperation();
                Console.WriteLine("kaboom :)"); }
            else if (input == "vnu-fetch") { VNUFetch.Init(); }
            else
            {
                Console.WriteLine("VNU: Bad command or filename. (did you type the command wrong, or the file path incorrectly?)");
            }
        }
    }
}
