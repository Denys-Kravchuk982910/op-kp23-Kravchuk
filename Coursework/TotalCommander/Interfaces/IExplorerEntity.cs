using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Interfaces
{
    public interface IExplorerEntity
    {
        void CreateEntity(string path, string file);
        void MoveEntity(string source, string destination);
        void DeleteEntity(string path);
    }
}
