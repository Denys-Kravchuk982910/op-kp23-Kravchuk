using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services
{
    public static class CommandService
    {
        public static string GetPath(string path) 
        {
            return path;
        }

        public static string Move(string source)
        {
            string[] items = source.Split("_from_");
            if(items.Length < 3)
            {
                return String.Empty;
            }
            string destination = items[0];
            string sourcePath = items[1];
            string destFileName = items[2];
            string root = items[3];

            if(sourcePath.Length < root.Length)
            {
                return String.Empty;
            }
            string fullPathDestination = Path.Combine(root, destination);
            if(Directory.Exists(fullPathDestination))
            {
                if(Directory.Exists(sourcePath))
                {
                    string dest = Path.Combine(fullPathDestination, destFileName);
                    Directory.Move(sourcePath, dest);
                }

                if(File.Exists(sourcePath))
                {
                    string dest = Path.Combine(fullPathDestination, destFileName);
                    File.Move(sourcePath, dest);
                }
            }

            return "";
        }

        public static string ChangeDirectory(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return "";
            }
            string line = str.Trim('/').Trim('\\');
            if (Directory.Exists(str) || Directory.Exists(Path.Combine(DirectoryService.StartPosition, line)))
            {

                if (line[1] == ':')
                {
                    DirectoryService.StartPosition = line;
                    return DirectoryService.StartPosition;
                }

                DirectoryService.StartPosition = Path.Combine(DirectoryService.StartPosition,
                    line);
            }
            return DirectoryService.StartPosition;
        }
    }
}
