using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Interfaces;

namespace TotalCommander.Abstracts
{
    public abstract class ExplorerEntity : IExplorerEntity
    {
        public string Name { get; protected set; }
        public string Path { get; protected set; }

        public ExplorerEntity(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public virtual void CreateEntity()
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteEntity()
        {
            throw new NotImplementedException();
        }

        public virtual void MoveEntity(string source, string destination)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
