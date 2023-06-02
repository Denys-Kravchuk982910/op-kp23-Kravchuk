using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Classes;

namespace TotalCommanderUnit.ClassesUnit
{
    public class LeftMenuUnit
    {
        private LeftMenu _leftMenu;

        public LeftMenuUnit()
        {
            _leftMenu = new LeftMenu(new List<TotalCommander.Abstracts.ExplorerEntity>
            {
                // List of folders 
            });
        }

        public bool DisplayLeftMenuUnit()
        {
            //  Display items of left menu
            _leftMenu.DisplayLeftMenu();

            return true;
        }

        public bool SetNewItemsUnit()
        {
            _leftMenu.SetNewItems(new List<TotalCommander.Abstracts.ExplorerEntity>
            {
                new FileEntity("text1.txt", Directory.GetCurrentDirectory())
            });
            return _leftMenu.GetCount() == 2;
        }

        public bool ClearItems()
        {
            _leftMenu.ClearItems();
            
            return _leftMenu.GetCount() == 0;
        }
    }
}
