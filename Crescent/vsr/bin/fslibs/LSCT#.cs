using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.FsCMDS
{
    public class LSCT
    {
        public static void Run(string filePath)
        {
            try
            {
                Console.WriteLine(File.ReadAllText(filePath.Substring(5)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.\n" + ex.Message);
            }
        } 
    }
}
