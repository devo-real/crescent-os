using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.MiscCMDS
{
    internal class Echo
    {
        public static void Init(string input)
        {
            Console.WriteLine(input.Substring(5)); 
        }
    }
}
