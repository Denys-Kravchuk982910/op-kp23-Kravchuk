using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services
{
    public static class DirectoryService
    {
        public static string WindowsUserName = WindowsIdentity.GetCurrent().Name.ToString().Split("\\")[1];
        public static string StartPosition = Path.Combine("C:", "Users", WindowsUserName, "Desktop");
        public static List<FileSystemInfo> GetInnerFromDirectory(string path) 
        {
            List<FileSystemInfo> inners = new List<FileSystemInfo>();

            foreach (var directory in Directory.GetDirectories(path))
            {
                inners.Add(new DirectoryInfo(directory));
            }
            
            foreach (var file in Directory.GetFiles(path))
            {
                inners.Add(new FileInfo(file));
            }

            return inners;
        }
    }
}
