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
            var defBack = Console.BackgroundColor;
            int index = 0;
            ConsoleKey key =ConsoleKey.Enter;
            while (key != ConsoleKey.Escape)
            {
                int count = 0;
                ExplorerEntity item = null;
                if (_isLeftRight)
                {
                    _leftMenu.DisplayLeftMenu(this.pageLeft);
                    item = _leftMenu.GetItemByIndex(index);
                    Console.SetCursorPosition(10, Top + index);
                    count = _leftMenu.GetCount();
                }

                if (!_isLeftRight)
                {
                    _rightMenu.DisplayRightMenu();
                    item = _rightMenu.GetItemByIndex(index);
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 3, Top + index);
                    count = _rightMenu.GetCount();
                }

                Console.BackgroundColor = ConsoleColor.White;

                Console.WriteLine(item.Name);
               
               
                
                key = Console.ReadKey(true).Key;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                switch (key)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {
                            
                            index++;
                            if(index >= count)
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
                                index = sizeOfColumn-1;
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
                                if(_rightMenu.GetCount() > _leftMenu.GetCount())
                                {
                                    index = _leftMenu.GetCount() - 1;
                                }
                                _isLeftRight = true;
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
                                if (_rightMenu.GetCount() < _leftMenu.GetCount())
                                {
                                    index = _rightMenu.GetCount() - 1;
                                }
                                _isLeftRight = false;
                            }
                            break;
                        }
                }

                Console.BackgroundColor = defBack;
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
