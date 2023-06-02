using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Services;

namespace TotalCommanderUnit.ServicesUnit
{
    public class CommandServiceUnit
    {
        public bool GetPathUnit()
        {
            return CommandService.GetPath("path") == "path";
        }

        public bool ChangeDirectoryUnit()
        {
            string WindowsUserName = WindowsIdentity.GetCurrent().Name.ToString().Split("\\")[1];
            string StartPosition = Path.Combine("C:", "Users", WindowsUserName, "Desktop");
            return CommandService.ChangeDirectory("dir1") == Path.Combine(StartPosition, "dir1");
        }
    }
}
