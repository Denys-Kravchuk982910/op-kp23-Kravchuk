using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Services;

namespace TotalCommanderUnit.ServicesUnit
{
    public class DirectoryServiceUnit
    {
        public bool GetInnerFromDirectoryUnit()
        {
            List<FileSystemInfo> files = DirectoryService
                .GetInnerFromDirectory(Path.Combine(Directory.GetCurrentDirectory()));


            if(files.Count == 11)
            {
                return true;
            }

            return false;
        }
    }
}
