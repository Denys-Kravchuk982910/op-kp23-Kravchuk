using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services
{
    public static class FileService
    {
        public static void CreateFile(string path, string name)
        {
            var stream = File.CreateText(Path.Combine(path, name));
            stream.Dispose();
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public static void MoveFile(string source, string destination)
        {
            File.Move(source, destination);
        }
    }
}
