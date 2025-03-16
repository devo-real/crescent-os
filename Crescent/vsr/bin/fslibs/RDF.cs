using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace VNU.FsCMDS
{
    internal class RDF
    {
        public static void Init(string file)
        {
            string filePath = file.Substring(4); 

            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Error: File path cannot be empty.");
                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    Console.WriteLine("File deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}
