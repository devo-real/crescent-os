using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.FsCMDS
{
    internal class RD
    {
        public static void Init(string input)
        {
            string dirPath = input.Substring(3).ToString();
            if (string.IsNullOrEmpty(dirPath))
            {
                Console.WriteLine("Error: Directory path cannot be empty.");
                return;
            }

            if (Directory.Exists(dirPath))
            {
                try
                {
                    if (dirPath == @"\" || dirPath == @"0:\root" || dirPath == @"0:\" || dirPath == @"0:\\")
                    {
                        Security.ScaryOperation.RaiseScaryOperation();
                        Directory.Delete(dirPath);
                    }

                    else
                    {
                        Directory.Delete(dirPath);
                        Console.WriteLine("Directory deleted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }
        }
    }
}
