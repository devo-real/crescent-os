using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;
using Console = System.Console;

namespace Crescent.SysResource
{
    class Bootloader
    {
        public static bool bootmenu = true;

        public static void KernelEntry()
        {
            try
            {
                Console.WriteLine("Booting " + Kernel.OSKERNEL + " " + Kernel.OSNAME);
            }
            catch
            {
                Console.WriteLine("Error booting " + Kernel.OSNAME + ". The kernel may be unreadable and corrupt.");
            }
        }

        private static string[] menuOptions = { "Crescent OS", "Settings", "Reboot", "Shutdown" };
        private static int selectedIndex = 0;

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Lunar Bootloader ===\n");
            DrawMenu();
        }

        private static void DrawMenu()
        {
            while (bootmenu)
            {
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"> {menuOptions[i]} <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                }
                HandleInput();
            }
        }

        private static void HandleInput()
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length;
                    RefreshScreen();
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % menuOptions.Length;
                    RefreshScreen();
                    break;
                case ConsoleKey.Enter:
                    ExecuteOption();
                    break;
            }
        }

        private static void RefreshScreen()
        {
            Console.Clear();
            Console.WriteLine("=== Lunar Bootloader ===\n");
        }

        private static void ExecuteOption()
        {
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Starting Crescent...");
                    KernelEntry();
                    bootmenu = false;
                    break;
                case 1:
                    Console.WriteLine("Entering Settings...");
                    break;
                case 2:
                    Console.WriteLine("Rebooting...");
                    Power.Reboot();
                    break;
                case 3:
                    Console.WriteLine("Shutting down...");
                    Power.Shutdown();
                    break;
            }
        }
    }
}
