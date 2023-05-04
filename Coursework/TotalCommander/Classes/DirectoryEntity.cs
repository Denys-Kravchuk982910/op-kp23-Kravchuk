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

        public DirectoryEntity(DirectoryInfo directoryInfo)
        {
            this._directoryInfo = directoryInfo;
            this.Name = directoryInfo.Name;
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
