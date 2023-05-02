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
                inners.Add(new DirectoryInfo(file));
            }

            return inners;
        }

        public static void CreateDirectory (string path, string name)
        {
            Directory.CreateDirectory(Path.Combine(path, name));
        }

        public static void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }

        public static void MoveDirectory(string source, string destination)
        {
            Directory.Move(source, destination);
        }
    }
}
