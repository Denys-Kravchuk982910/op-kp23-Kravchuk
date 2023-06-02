using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Classes;

namespace TotalCommanderUnit.ClassesUnit
{
    public class RightMenuUnit
    {
        private RightMenu _rightMenu;

        public RightMenuUnit()
        {
            _rightMenu = new RightMenu(new List<TotalCommander.Abstracts.ExplorerEntity>
            {
                // List of folders 
            });
        }

        public bool DisplayLeftMenuUnit()
        {
            //  Display items of left menu
            _rightMenu.DisplayRightMenu();

            return true;
        }

        public bool SetNewItemsUnit()
        {
            _rightMenu.SetNewItems(new List<TotalCommander.Abstracts.ExplorerEntity>
            {
                new FileEntity("text1.txt", Directory.GetCurrentDirectory())
            });
            return _rightMenu.GetCount() == 2;
        }

        public bool ClearItems()
        {
            _rightMenu.ClearItems();

            return _rightMenu.GetCount() == 0;
        }
    }
}
