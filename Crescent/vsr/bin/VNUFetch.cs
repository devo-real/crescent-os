using Cosmos.Core;
using Crescent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNU.MiscCMDS
{
    class VNUFetch
    {
        public static void Init()
        {
            List<string> fatTypes = new List<string>
            {
                "FAT12",
                "FAT16",
                "FAT32",
                "exFAT"
            };

            List<string> extTypes = new List<string>
            {
                "ext",
                "ext2",
                "ext3",
                "ext4"
            };

            string fsType;

            if (fatTypes.Contains(Kernel.fileSystem.GetFileSystemType("0:\\")))
            {
                fsType = "File Allocation Table";
            }

            else if (extTypes.Contains(Kernel.fileSystem.GetFileSystemType("0:\\")))
            {
                fsType = "Extended Filesystem";
            }

            else
            {
                fsType = "Other";
            }

                Console.WriteLine(@$"     
            ████                  
        ████                      
     ████      OS: {Kernel.OSNAME}              
    ████       
   ████        CPU: {CPU.GetCPUBrandString()}      
  ████         RAM: {(CPU.GetEndOfKernel() + 1024) / 1048576} / {CPU.GetAmountOfRAM()} MB
 █████          
 █████         Disk: {Kernel.fileSystem.GetAvailableFreeSpace("0:\\") / 1048576} free / {Kernel.fileSystem.GetTotalSize("0:\\") / 1048576} MB                    
 █████         Filesystem: {Kernel.fileSystem.GetFileSystemType("0:\\")} ({fsType})                  
 ?????                            
  █████        Kernel: {Kernel.OSKERNEL}
   █████       pc@user: {Kernel.PCNAME}@{Kernel.ROOTUSERNAME}                   
    █████                         
     ██████             █           
       ████████      ███           
           ██████████                   
");
        }
    }
}
