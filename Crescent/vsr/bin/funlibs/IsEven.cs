using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crescent.Fun
{
    class IsEven
    {
        public static void Init(int? value)
        {
            try
            {
                if ((value & 1) == 0)
                {
                    Console.WriteLine("Even.");
                }
                else
                {
                    Console.WriteLine("Odd.");
                }
            }
            catch (Exception err) { Console.WriteLine(err.Message); }
        }
    }
}
