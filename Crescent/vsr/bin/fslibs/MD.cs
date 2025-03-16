using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.FsCMDS
{
    internal class MD
    {
        public static void Init(string path)
        {
            try
            {
                Directory.CreateDirectory(CD.CurrentDirectory + @"\" + path.Substring(3));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.\n" + ex.Message);
            }
        }
    }
}
