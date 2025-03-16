using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Crescent.Fun
{
    class Slots
    {
        static readonly Random random = new Random();
        static readonly int[] symbols = { 1, 2, 3, 4, 5, 6, 7 }; // Numbers instead of emojis

        public static void Play()
        {
            int balance = 100;
            while (balance > 0)
            {
                Console.Clear();
                Console.WriteLine($"Balance: ${balance}");
                Console.Write("Enter bet amount: ");
                if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0 || bet > balance)
                {
                    Console.WriteLine("Invalid bet. Try again.");
                    Thread.Sleep(1000);
                    continue;
                }

                balance -= bet;
                int[] result = SpinReels();
                DisplayReels(result);
                int winnings = CalculateWinnings(result, bet);
                balance += winnings;

                Console.WriteLine(winnings > 0 ? $"You won ${winnings}!" : "You lost this round.");
                Console.WriteLine("Press Enter to spin again or type 'exit' to quit.");
                if (Console.ReadLine()?.ToLower() == "exit") break;
            }
            Console.WriteLine("Game Over! Thanks for playing.");
        }

        public static int[] SpinReels()
        {
            return new int[] { symbols[random.Next(symbols.Length)], symbols[random.Next(symbols.Length)], symbols[random.Next(symbols.Length)] };
        }

        public static void DisplayReels(int[] reels)
        {
            Console.WriteLine($"[ {reels[0]} ] [ {reels[1]} ] [ {reels[2]} ]");
        }

        public static int CalculateWinnings(int[] reels, int bet)
        {
            if (reels.All(x => x == reels[0])) // Three of a kind
            {
                return bet * (reels[0] == 7 ? 10 : 5); // 7 is the highest multiplier
            }
            if (reels.Distinct().Count() == 2) // Two of the same
            {
                return bet * 2;
            }
            return 0;
        }
    }
}
