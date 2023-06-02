using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Abstracts;

namespace TotalCommander.Classes
{
    public class DirectoryEntity : ExplorerEntity
    {
        private DirectoryInfo _directoryInfo { get; set; }

        public DirectoryEntity(string path, string name) : base(name, path)
        {

        }

        public DirectoryEntity(DirectoryInfo directoryInfo) : base(directoryInfo.Name, directoryInfo!.Parent!.FullName)
        {
            this._directoryInfo = directoryInfo;
        }

        public override void CreateEntity()
        {
            string directory = System.IO.Path.Combine(this.Path, this.Name);
            if (!Directory.Exists(directory))
            {
                _directoryInfo = Directory.CreateDirectory(directory);
            }
        }

        public override void DeleteEntity()
        {
            if(_directoryInfo != null)
            {
                _directoryInfo.Delete(true);
            }
        }


    }
}
