using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Interfaces;

namespace TotalCommander.Data
{
    public abstract class Storage<T> : IStorage<T> where T :class
    {
        private string path;
        protected Dictionary<string,T> _storage;
        public Storage(string path)
        {
            if(!File.Exists(path))
            {
                var fs = File.Create(path);
                fs.Close();
            }
            this.path = path;
            this.GetAllLines();
        }
        public virtual Dictionary<string, T> GetAllLines()
        {
            this._storage = new Dictionary<string, T>();
            if (_storage.Count <= 0)
            {
                string[] strs = File.ReadAllLines(this.path);
                foreach (var str in strs)
                {
                    this._storage.Add(str, null);
                }
            }

            return this._storage;
        }

        public virtual T GetByIndex(string param)
        {
            return this._storage[param];
        }
    }
}
