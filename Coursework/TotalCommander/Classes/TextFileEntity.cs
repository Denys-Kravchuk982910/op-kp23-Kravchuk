using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Classes
{
    public class TextFileEntity : FileEntity
    {
        public TextFileEntity(FileInfo file) : base(file)
        {
        }
        public override void CreateEntity(string path, string file)
        {
            base.CreateEntity(path, file);
        }

        public override void MoveEntity(string source, string destination)
        {
            base.MoveEntity(source, destination);
        }

        public override void DeleteEntity(string path)
        {
            base.DeleteEntity(path);
        }
    }
}
