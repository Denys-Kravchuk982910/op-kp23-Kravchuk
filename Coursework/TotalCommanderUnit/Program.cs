using System;
using TotalCommanderUnit.ClassesUnit;
using TotalCommanderUnit.DataUnit;
using TotalCommanderUnit.ServicesUnit;

namespace TotalCommanderUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryServiceUnit directoryServiceUnit = new DirectoryServiceUnit();

            if(directoryServiceUnit.GetInnerFromDirectoryUnit())
            {
                Console.WriteLine("Inner files were got successfully!");
            }

            CommandServiceUnit commandServiceUnit = new CommandServiceUnit();
            if(commandServiceUnit.GetPathUnit() && commandServiceUnit.ChangeDirectoryUnit())
            {
                Console.WriteLine("CommandService works stable!");
            }


            CommandStorageUnit commandStorageUnit = new CommandStorageUnit();

            if(commandStorageUnit.GetAllLines() && commandStorageUnit.GetByIndex())
            {
                Console.WriteLine("CommandStorage works stable!");
            }


            DirectoryEntityUnit directoryEntity = new DirectoryEntityUnit();

            if(directoryEntity.CreateEntity() && directoryEntity.DeleteEntity())
            {
                Console.WriteLine("DirectoryEntity works stable!");
            }

            FileEntityUnit fileEntity = new FileEntityUnit();

            if (fileEntity.CreateEntity() && fileEntity.DeleteEntity())
            {
                Console.WriteLine("FileEntity works stable!");
            }

            TextFileEntityUnit textFileEntity = new TextFileEntityUnit();

            if (textFileEntity.CreateEntity() && textFileEntity.DeleteEntity())
            {
                Console.WriteLine("TextFileEntity works stable!");
            }

            LeftMenuUnit leftMenuUnit = new LeftMenuUnit();

            if(leftMenuUnit.SetNewItemsUnit() && leftMenuUnit.ClearItems())
            {
                Console.WriteLine("LeftMenu works stable!");
            }

            RightMenuUnit rightMenuUnit = new RightMenuUnit();

            if (rightMenuUnit.SetNewItemsUnit() && rightMenuUnit.ClearItems())
            {
                Console.WriteLine("RightMenu works stable!");
            }
        }
    }
}
