using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Interfaces
{
    public interface IExplorerEntity
    {
        void CreateEntity();
        void MoveEntity(string source, string destination);
        void DeleteEntity();
    }
}
