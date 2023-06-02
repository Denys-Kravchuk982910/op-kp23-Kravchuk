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

        public FileEntity(string name, string path) : base(name, path)
        {
        }


        public FileEntity(FileInfo fileInfo) : base(fileInfo.Name, fileInfo!.Directory!.FullName)
        {
            _fileInfo = fileInfo;
        }

        public override void CreateEntity()
        {
            string file = System.IO.Path.Combine(this.Path, this.Name);
            if(!File.Exists(file))
            {

                FileStream fs = File.Create(file);
                fs.Dispose();
                _fileInfo = new FileInfo(file);
            }
        }

        public override void DeleteEntity()
        {
            if(this._fileInfo != null)  
                this._fileInfo.Delete();
        }
    }
}
