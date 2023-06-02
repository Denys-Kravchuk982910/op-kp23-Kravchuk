using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Classes;

namespace TotalCommanderUnit.ClassesUnit
{
    public class TextFileEntityUnit
    {
        private TextFileEntity fileEntity;
        public TextFileEntityUnit()
        {
            fileEntity = new TextFileEntity("unitFile.txt", Path.Combine(Directory.GetCurrentDirectory()));
        }
        public bool CreateEntity()
        {
            fileEntity.CreateEntity();
            bool isExists = File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "unitFile.txt"));
            if (isExists)
            {
                return true;
            }

            return false;
        }

        public bool DeleteEntity()
        {
            fileEntity.DeleteEntity();
            bool isExists = Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "unitFile.txt"));
            if (!isExists)
            {
                return true;
            }

            return false;
        }
    }
}
