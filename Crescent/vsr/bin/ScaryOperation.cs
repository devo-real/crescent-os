using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.Security
{
    public class ScaryOperation
    {
        public static void RaiseScaryOperation()
        {
            Console.WriteLine("Warning: You have entered a command that has been flagged as a Scary Operation.\n" +
                "This means that the command you have entered could be seriously harmful and\ncould brick your OS, " +
                "drives, firmware, apps, and even hardware.\n" +
                "To proceed, type 'I know what I am doing, run the command!'.\n--- TYPE HERE ---");
            string input = Console.ReadLine();
            switch (input)
            {
                case "I know what I am doing, run the command!":
                    break;

                default:
                    Console.WriteLine("E: Input does not match criteria."); break;
            }
        }
    }
}
