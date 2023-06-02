using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Classes;
using TotalCommander.Interfaces;
using TotalCommander.Services;

namespace TotalCommander.Abstracts
{
    public class Menu : IMenu
    {
        protected int pages = 0;
        protected List<ExplorerEntity> _explorerEntities;
        protected string CurrentPosition;

        public string GetCurrentPosition()
        {
            return this.CurrentPosition;
        }

        public void SetCurrentPosition(string pos)
        {
             this.CurrentPosition = pos;
        }

        public int GetCount()
        {
            return _explorerEntities.Count;
        }

        public int GetPages()
        {
            return this.pages;
        }

        public ExplorerEntity GetItemByIndex(int index)
        {
            return _explorerEntities[index];
        }

        public Menu(List<ExplorerEntity> explorerEntities)
        {
            this.CurrentPosition = DirectoryService.StartPosition;
            this._explorerEntities = new List<ExplorerEntity>();
            
            this._explorerEntities.Add(new DirectoryEntity(new DirectoryInfo(Path.Combine(this.GetCurrentPosition(),
                ".."))));
            this._explorerEntities.AddRange(explorerEntities);
            double res = (double)this._explorerEntities.Count / 31;
            double floored = Math.Ceiling(res);
            this.pages = (int)floored;
        }

        public virtual void DisplayItemsWithMenu()
        {
            foreach (var file in this._explorerEntities)
            {
                Console.WriteLine(file);
            }
        }

        public void UpdateMenu() 
        {
            ClearItems();

            SetNewItems(new List<ExplorerEntity>(
                DirectoryService.GetInnerFromDirectory(
                this.GetCurrentPosition()) 
                .Select(x => MainMenu.GetType(x))
                ));
        }

        public void ClearItems()
        {
            this._explorerEntities.Clear();
            
        }

        public void SetNewItems(List<ExplorerEntity> explorerEntities)
        {
            this._explorerEntities = new List<ExplorerEntity>();
            this._explorerEntities.Add(new DirectoryEntity(new DirectoryInfo(Path.Combine(this.GetCurrentPosition(), 
                ".."))));
            this._explorerEntities.AddRange( explorerEntities);
            double res = (double)this._explorerEntities.Count / 31;
            double floored = Math.Ceiling(res);
            this.pages = (int)floored;
        }
    }
}
