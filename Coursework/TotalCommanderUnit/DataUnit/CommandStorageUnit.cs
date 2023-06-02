using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Data;
using TotalCommander.Services;

namespace TotalCommanderUnit.DataUnit
{
    public class CommandStorageUnit
    {
        private CommandStorage _storage;
        public CommandStorageUnit()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Local", "commands.csv");
            _storage = new CommandStorage(path);
        }
        public bool GetAllLines()
        {
            return _storage.GetAllLines().Count == 3;
        }

        public bool GetByIndex()
        {
            return _storage.GetByIndex("mv") != null && 
                _storage.GetByIndex("cd") != null && 
                _storage.GetByIndex("pwd") != null;
        }
    }
}
