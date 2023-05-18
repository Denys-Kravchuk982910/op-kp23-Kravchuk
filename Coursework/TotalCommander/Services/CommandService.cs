using System;
using System.Collections.Generic;
using System.Linq;
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
            string destination = items[0];
            string sourcePath = items[1];
            string sourceName = items[2];

            return "";
        }

        public static string ChangeDirectory(string str)
        {
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
