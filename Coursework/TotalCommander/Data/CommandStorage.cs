using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Services;

namespace TotalCommander.Data
{
    public class CommandStorage : Storage<Delegate>
    {
        public CommandStorage(string path) : base(path)
        {
        
        }

        public override Dictionary<string, Delegate> GetAllLines()
        {
            Dictionary<string, Delegate> dict=base.GetAllLines();

            foreach (var item in dict)
            {
                switch (item.Key)
                {
                    case "pwd":
                        {
                            Func<string, string> act = CommandService.GetPath;
                            dict["pwd"] = act;
                            break;
                        }
                    case "mv":
                        {
                            Func<string, string> act = CommandService.Move;
                            dict["mv"] = act;
                            break;
                        }
                    case "cd":
                        {
                            Func<string, string> func = CommandService.ChangeDirectory;
                            dict["cd"] = func;
                            break; 
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            this._storage = dict;
            return dict;
        }

        public Delegate this[string key]
        {
            get => GetByIndex(key);
        }

        public override Delegate GetByIndex(string param)
        {
            if (!this._storage.ContainsKey(param))
            {
                return null;
            }
            return this._storage[param];
        }
    }
}
