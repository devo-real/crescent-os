using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Crescent.Fun
{
    class Fib
    {
        public static void Init(string args)
        {
            long count = long.Parse(args.Substring(4));

            long a = 1;
            long b = 0;
            long p = 0;
            long q = 1;

            long tmp;

            while (count > 0)
            {
                if (count % 2 == 0)
                {
                    tmp = q * q;
                    q = q * p * 2 + tmp;
                    p = p * p + tmp;

                    count /= 2;
                }
                else
                {
                    tmp = a * q;

                    a = a * p + b * q + tmp;
                    b = b * p + tmp;

                    count -= 1;
                }
            }

            // Print the results to standard out
            Console.WriteLine(b);
        }
    }
}