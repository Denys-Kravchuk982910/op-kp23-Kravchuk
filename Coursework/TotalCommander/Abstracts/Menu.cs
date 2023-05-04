using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Interfaces;

namespace TotalCommander.Abstracts
{
    public class Menu : IMenu
    {
        protected int pages = 0;
        protected List<ExplorerEntity> _explorerEntities;

        public int GetCount()
        {
            return _explorerEntities.Count;
        }

        public int GetPages ()
        {
            return this.pages;
        }

        public ExplorerEntity GetItemByIndex(int index)
        {
            return _explorerEntities[index];
        }
        public Menu(List<ExplorerEntity> explorerEntities)
        {
            this._explorerEntities = explorerEntities;  
            this.pages = (int)Math.Floor((double)this._explorerEntities.Count / 31);
        }

        public virtual void DisplayItemsWithMenu()
        {
            foreach (var file in this._explorerEntities)
            {
                Console.WriteLine(file);
            }
        }
    }
}
