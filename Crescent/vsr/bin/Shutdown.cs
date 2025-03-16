using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;

namespace VNU.PowerCMDS
{
    internal class Shutdown
    {
        public static void Init()
        {
            Cosmos.System.Power.Shutdown();
        }
    }
}
