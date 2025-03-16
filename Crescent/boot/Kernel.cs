using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem.FAT;
using Cosmos.System.FileSystem.VFS;
using VNU.root;
using System.IO;
using Cosmos.Core;
using System.Threading;
using Cosmos.Core.IOGroup;
using Crescent.SysResource;



namespace Crescent
{
    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS fileSystem = new();
        public static bool running = true; // This is to be enabled true by the bootloader.

        public static readonly string ROOTDISK = @"0:\";
        public static readonly string ROOTUSERNAME = "root";
        public static readonly string OSNAME = "VNU/Crescent";
        public static readonly string OSKERNEL = "vnu-kernel-v1";
        public static string PCNAME = "crescent-OS";

        protected override void OnBoot()
        {
            base.OnBoot();
            Bootloader.ShowMenu();
        }

        protected override void BeforeRun()
        {
            Scripts.All();
            Scripts.OFailStat(true, "Booted main VNU kernel. Welcome to Crescent!");
            Thread.Sleep(500);
            Console.Clear();
            Console.Clear();
            Scripts.BoopBeepBeepBoop();
        }

        protected override void Run()
        {
            if (running)
            {
                VNU.root.CommandPrompt.CMD();
            }

            else
            {
                Sys.Power.Shutdown();
            }
        }
    }

    public class Scripts : Kernel
    {
        public static void All()
        {
            try
            {
                OFailStat(true, "Starting OS initialization scripts.");
                FS();
                DetectHardware();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public static void OFailStat(bool successful, string msg)
        {
            try
            {
                Console.Write("[");
                if (successful)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("  OK  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FAILED");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("] " + msg + "\n");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public static void FS()
        {
            try
            {
                VFSManager.RegisterVFS(fileSystem);
                OFailStat(true, $"{fileSystem.GetFileSystemType("0:\\")} filesystem initialized successfully");
                Thread.Sleep(50);
            }
            catch (Exception err)
            {
                OFailStat(false, "Filesystem failed to initialize. " + err.Message);
                Thread.Sleep(50);
            }
        }

        public static void DetectHardware()
        {

            try
            {
                OFailStat(true, $"Detecting hardware.\n        {fileSystem.GetFileSystemType("0:\\")} filesystem\n" +
                    $"        {CPU.GetAmountOfRAM()} megabytes of RAM\n" +
                    $"        {CPU.GetCPUBrandString()} CPU\n" + 
                    $"        {fileSystem.GetTotalSize("0:\\") / 1024 / 1024} megabytes on disk\n" +
                    $"        {fileSystem.GetAvailableFreeSpace("0:\\") / 1024 / 1024} megabytes of free space on disk");
            }
            catch
            {
                OFailStat(false, "Failed to detect hardware!");
            }
        }

        public static void BoopBeepBeepBoop()
        {

            try
            {
                Console.WriteLine(@"



                   X=======================================X
                   I                                       I
                   I       CRESCENT OPERATING SYSTEM       I
                   I   You are now in the VNU/Crescent OS  I
                   I            shell prompt.              I
                   I    Run 'vnu-fetch' for system info.   I
                   I                                       I  
                   X=======================================X
");
                Sys.PCSpeaker.Beep((uint)Sys.Notes.E4, 500);
                Sys.PCSpeaker.Beep((uint)Sys.Notes.A4, 500);
                Sys.PCSpeaker.Beep((uint)Sys.Notes.B4, 500);
                Sys.PCSpeaker.Beep((uint)Sys.Notes.E5, 500);
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Unable to play chime. :(");
            }
        }
    }
}

