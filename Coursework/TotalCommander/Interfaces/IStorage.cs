using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Interfaces
{
    public interface IStorage<Key>
    {
        Dictionary<string, Key> GetAllLines();
        Key GetByIndex(string param);
    }
}
