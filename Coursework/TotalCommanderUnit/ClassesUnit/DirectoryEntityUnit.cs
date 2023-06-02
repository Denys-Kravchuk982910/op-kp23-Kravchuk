using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Classes;

namespace TotalCommanderUnit.ClassesUnit
{
    public class DirectoryEntityUnit
    {
        private DirectoryEntity directoryEntity;
        public DirectoryEntityUnit()
        {
            directoryEntity = new DirectoryEntity(Path.Combine(Directory.GetCurrentDirectory()), "unitDirectory");
        }
        public bool CreateEntity()
        {
            directoryEntity.CreateEntity();
            bool isExists = Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "unitDirectory"));
            if (isExists)
            {
                return true;
            }

            return false;
        }

        public bool DeleteEntity()
        {
            directoryEntity.DeleteEntity();
            bool isExists = Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "unitDirectory"));
            if (!isExists)
            {
                return true;
            }

            return false;  
        }
    }
}
