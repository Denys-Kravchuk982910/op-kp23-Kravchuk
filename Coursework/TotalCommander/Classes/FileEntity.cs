using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Abstracts;

namespace TotalCommander.Classes
{
    public class FileEntity : ExplorerEntity
    {
        protected FileInfo _fileInfo { get; set; }
        protected string Extension;

        public FileEntity(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
            this.Name = fileInfo.Name;
            this.Extension = fileInfo.Extension;
            this.Path = fileInfo.FullName;

        }

        public override void CreateEntity(string path, string file)
        {
            base.CreateEntity(path, file);
        }

        public override void DeleteEntity(string path)
        {
            base.DeleteEntity(path);
        }
        public override void MoveEntity(string source, string destination)
        {
            base.MoveEntity(source, destination);
        }
    }
}
