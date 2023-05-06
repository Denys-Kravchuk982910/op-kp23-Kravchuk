using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Abstracts;
using TotalCommander.Services;

namespace TotalCommander.Classes
{
    public class MainMenu
    {
        private int pageLeft = 0;
        private int pageRight = 0;
        private int sizeOfColumn = 31;
        private int Top { get; set; } = 9;
        private LeftMenu _leftMenu { get; set; }
        private RightMenu _rightMenu { get; set; }

        private bool _isLeftRight = true;
        public MainMenu()
        {
            _leftMenu = new LeftMenu(new List<ExplorerEntity>(
                DirectoryService.GetInnerFromDirectory(
                DirectoryService.StartPosition)
                .Select(x => GetType(x))
                ));

            _rightMenu = new RightMenu(new List<ExplorerEntity>(
                DirectoryService.GetInnerFromDirectory(
                DirectoryService.StartPosition)
                .Select(x => GetType(x))
                ));
        }

        public void StartApplication()
        {
            bool isPrinted = false;
            bool isPrintedEnd = false;
            var defBack = Console.BackgroundColor;
            int index = 0;
            ConsoleKey key = ConsoleKey.Enter;
            while (key != ConsoleKey.Escape)
            {
                int count = 0;
                ExplorerEntity item = null;
                if (_isLeftRight)
                {
                    _leftMenu.DisplayLeftMenu(this.pageLeft);
                    item = _leftMenu.GetItemByIndex(this.pageLeft * sizeOfColumn + index);
                    Console.SetCursorPosition(10, Top + index);
                    count = _leftMenu.GetCount();
                }

                if (!_isLeftRight)
                {
                    _rightMenu.DisplayRightMenu(this.pageRight);
                    item = _rightMenu.GetItemByIndex(this.pageRight * sizeOfColumn + index);
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 3, Top + index);
                    count = _rightMenu.GetCount();
                }

                Console.BackgroundColor = index != 0 ? ConsoleColor.White : ConsoleColor.Red;



                Console.WriteLine(item.Name);

                if(!isPrinted)
                {
                    key = Console.ReadKey(true).Key;
                }else
                {
                    isPrinted = false;
                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                switch (key)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {

                            index++;

                            if ((_isLeftRight ? this.pageLeft : this.pageRight) <
                                (_isLeftRight ? _leftMenu.GetPages() : _rightMenu.GetPages()) && index >= sizeOfColumn)
                            {

                                ClearSideOfMenu(_isLeftRight);
                                if (_isLeftRight)
                                    this.pageLeft++;
                                else
                                    this.pageRight++;


                                index = 0;
                                break;
                            }

                            if ((_isLeftRight ? this.pageLeft : this.pageRight) * sizeOfColumn + index >= count)
                            {

                                index = 0;
                                break;
                            }

                            break;
                        }
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            index--;
                            if (index < 0)
                            {
                                if (sizeOfColumn < count)
                                {
                                    index = sizeOfColumn - 1;

                                    if ((_isLeftRight ? pageLeft : pageRight) > 0)
                                    {
                                        this.ClearSideOfMenu(_isLeftRight);

                                        if (_isLeftRight)
                                        {
                                            this.pageLeft--;
                                        }

                                        if (!_isLeftRight)
                                        {
                                            this.pageRight--;
                                        }
                                    }
                                }

                                if (sizeOfColumn > count)
                                {
                                    index = count - 1;
                                }
                            }

                            break;
                        }
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        {
                            if (!_isLeftRight)
                            {
                                Console.SetCursorPosition(Console.WindowWidth / 2 + 3, Top + index);
                                Console.WriteLine(item.Name);
                                if (!isPrintedEnd && _rightMenu.GetCount() - this.pageRight * 31 > _leftMenu.GetCount() - this.pageLeft * 31)
                                {
                                    index = _leftMenu.GetCount() - this.pageLeft * 31 - 1;
                                    
                                }else
                                {
                                    index = 0;
                                }
                                _isLeftRight = true;
                                isPrintedEnd = false;
                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        {
                            if (_isLeftRight)
                            {
                                Console.SetCursorPosition(10, Top + index);
                                Console.WriteLine(item.Name);
                                if (!isPrintedEnd && _rightMenu.GetCount() - this.pageRight * 31 < _leftMenu.GetCount() - this.pageLeft * 31)
                                {
                                    index = _rightMenu.GetCount() - this.pageRight * 31 - 1;
                                }else
                                {
                                    index = 0;
                                }
                                _isLeftRight = false;
                                isPrintedEnd = false;
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (item is DirectoryEntity)
                            {
                                
                                string fullPath = item.Path;

                                DirectoryService.StartPosition = fullPath;

                                if (_isLeftRight)
                                {
                                    _rightMenu.ClearItems();
                                    _rightMenu.SetNewItems(new List<ExplorerEntity>(
                                        DirectoryService.GetInnerFromDirectory(
                                        fullPath)
                                        .Select(x => GetType(x))
                                    ));

                                    isPrinted = true;

                                }

                                if (!_isLeftRight)
                                {
                                    _leftMenu.ClearItems();
                                    _leftMenu.SetNewItems(new List<ExplorerEntity>(
                                        DirectoryService.GetInnerFromDirectory(
                                        fullPath)
                                        .Select(x => GetType(x))
                                    ));

                                    isPrinted = true;
                                }

                                ClearSideOfMenu(!_isLeftRight);
                                
                            }
                            break;
                        }
                }
                Console.BackgroundColor = defBack;

                if(isPrinted)
                {
                    key = _isLeftRight ? ConsoleKey.RightArrow : ConsoleKey.LeftArrow;
                    isPrintedEnd = true;
                }
            }
        }

        public void ClearSideOfMenu(bool isLeftRight)
        {
            int top = 9;
            int width = isLeftRight ? Console.WindowWidth / 2 : Console.WindowWidth-10;
            int left = isLeftRight ? 10 : Console.WindowWidth / 2 + 2;

            for (int i = 0; i < sizeOfColumn; i++)
            {
                for (int j = left; j < width; j++)
                {
                    Console.SetCursorPosition(j, top + i);
                    Console.Write(" ");
                }
            }
        }



        public ExplorerEntity GetType(FileSystemInfo item)
        {
            if (item is DirectoryInfo)
            {
                return new DirectoryEntity(item as DirectoryInfo);
            }

            if (item is FileInfo)
            {
                if (item.Extension == "txt")
                {
                    return new TextFileEntity(item as FileInfo);
                }

                return new FileEntity(item as FileInfo);
            }

            return null;
        }
    }
}
