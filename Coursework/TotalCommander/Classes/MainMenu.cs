using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Abstracts;
using TotalCommander.Data;
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

        private CommandStorage _commandStorage { get; set; }

        private bool _isLeftRight = true;

        bool isPrinted = false;
        public MainMenu()
        {
            _leftMenu = new LeftMenu(new List<ExplorerEntity>(
                DirectoryService.GetInnerFromDirectory(
                DirectoryService.StartPosition)
                .Select(x => GetType(x))
                ));
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Local", "commands.csv");
            _commandStorage = new CommandStorage(path);

            //_rightMenu = new RightMenu(new List<ExplorerEntity>(
            //    DirectoryService.GetInnerFromDirectory(
            //    DirectoryService.StartPosition)
            //    .Select(x => GetType(x))
            //    ));
        }

        public void StartApplication()
        {
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

                Console.BackgroundColor = index != 0 || (_isLeftRight ? this.pageLeft != 0 : this.pageRight!=0) ? ConsoleColor.White: ConsoleColor.Red;

                Console.WriteLine(item.Name);

                if(!isPrinted)
                {
                    key = Console.ReadKey(true).Key;
                }
                else
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
                                (_isLeftRight ? _leftMenu.GetPages() : _rightMenu.GetPages())-1 && index >= sizeOfColumn)
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
                                if (this.pageLeft == 0 && index == 0)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }

                                Console.SetCursorPosition(Console.WindowWidth / 2 + 3, Top + index);
                                Console.WriteLine(item.Name);
                                if (!isPrintedEnd && index > _leftMenu.GetCount() - this.pageLeft * 31)
                                {
                                    if (_leftMenu.GetCount() - this.pageLeft * 31 < sizeOfColumn && 
                                        index > _leftMenu.GetCount() - this.pageLeft * 31)
                                    {
                                        index = _leftMenu.GetCount() - this.pageLeft * 31 - 1;
                                    }                                    
                                }


                                _isLeftRight = true;


                                if (isPrintedEnd)
                                    index = 0;
                                isPrintedEnd = false;

                                if (this.pageLeft == 0 && index == 0)
                                {
                                    Console.BackgroundColor = defBack;
                                }
                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        {
                            if (_isLeftRight && _rightMenu != null)
                            {
                                if(this.pageLeft == 0 && index == 0)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                                Console.SetCursorPosition(10, Top + index);
                                Console.WriteLine(item.Name);
                                if (!isPrintedEnd && index < _leftMenu.GetCount() - this.pageLeft * 31)
                                {
                                    if(_rightMenu.GetCount() - this.pageRight * 31 < sizeOfColumn && index > 
                                        _rightMenu.GetCount() - this.pageRight * 31)
                                    {
                                        index = _rightMenu.GetCount() - this.pageRight * 31 - 1;
                                    }
                                }

                                _isLeftRight = false;

                                if (isPrintedEnd)
                                    index = 0;
                                isPrintedEnd = false;

                                if (this.pageLeft == 0 && index == 0)
                                {
                                    Console.BackgroundColor = defBack;
                                }
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (item is DirectoryEntity)
                            {
                                string fullPath = Path.Combine(item.Path, item.Name);

                                DirectoryService.StartPosition = fullPath;

                                OnEnterButton(fullPath);
                            }
                            break;
                        }
                    case ConsoleKey.M:
                        {
                            string directoryName = DesignOfWindow.ClearConsoleLine("Enter new folder name: ", true);
                            DirectoryEntity file = new DirectoryEntity(
                                _isLeftRight ? _leftMenu.GetCurrentPosition() : _rightMenu!.GetCurrentPosition()
                                , directoryName);


                            file.CreateEntity();

                            ClearSideOfMenu(_isLeftRight);
                            if (_isLeftRight)
                            {
                                _leftMenu.UpdateMenu();
                            }
                            else
                            {
                                _rightMenu?.UpdateMenu();
                            }

                            break;
                        }
                    case ConsoleKey.F:
                        {
                            string fileName = DesignOfWindow.ClearConsoleLine("Enter new file name: ", true);
                            FileEntity file = null;
                            if(fileName.EndsWith(".txt") || !fileName.Contains("."))
                            {
                                string inside = DesignOfWindow.ClearConsoleLine("Enter content to the file: ", true);
                                file = new TextFileEntity(fileName,

                                    _isLeftRight ? _leftMenu.GetCurrentPosition() : _rightMenu!.GetCurrentPosition(), inside);
                                
                            }else
                            {
                                file = new FileEntity(fileName,
                                    _isLeftRight ? _leftMenu.GetCurrentPosition() : _rightMenu!.GetCurrentPosition()
                                    );
                            }

                            file.CreateEntity();
                            ClearSideOfMenu(_isLeftRight);
                            if (_isLeftRight)
                            {
                                _leftMenu.UpdateMenu();
                            }
                            else
                            {
                                _rightMenu?.UpdateMenu();

                            }

                            break;
                        }
                    case ConsoleKey.T:
                        {
                            if (index != 0 || (_isLeftRight ? this.pageLeft > 0 : this.pageRight > 0))
                            {
                                item.DeleteEntity();
                                ClearSideOfMenu(_isLeftRight);

                                index--;

                                int itemsCount = (_isLeftRight ? this._leftMenu.GetCount() : this._rightMenu.GetCount())-1;
                                int countOfPage = (_isLeftRight ? (this.pageLeft+1) * sizeOfColumn : (this.pageRight+1) * sizeOfColumn)
                                    -sizeOfColumn;
                                if (index < 0 && itemsCount <= countOfPage) 
                                {
                                    if (_isLeftRight)
                                        this.pageLeft--;
                                    else
                                        this.pageRight--;

                                    index = sizeOfColumn-1;
                                }else
                                {
                                    index = 0;
                                }

                                if (_isLeftRight)
                                {
                                    _leftMenu.UpdateMenu();
                                }
                                else
                                {
                                    _rightMenu?.UpdateMenu();

                                }
                                

                            }
                            break;
                        }
                    case ConsoleKey.C:
                        {
                            string commandText = DesignOfWindow.ClearConsoleLine("/# ", true);
                            string param = "";
                            string command = "";

                            int counter = 0;
                            do
                            {
                                command += commandText[counter];
                                counter++;
                            }
                            while (counter < commandText.Length && commandText[counter] != ' ');
                            counter++;

                            for (int i = counter; i < commandText.Length; i++) 
                            {
                                param += commandText[i];
                            }

                            int countOfEntities = commandText.Split(" ").Length;
                            string result = (string)_commandStorage[command].DynamicInvoke(
                                countOfEntities > 1 ? param : item.Path
                                )!;

                            switch (command)
                            {
                                case "cd":
                                    {
                                        OnEnterButton(DirectoryService.StartPosition);
                                        break;
                                    }
                                case "pwd":
                                    {
                                        DesignOfWindow.ClearConsoleLine("/# " + result + " - Press enter", true);
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
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

        public void OnEnterButton(string fullPath)
        {
            if (_rightMenu == null)
            {
                _rightMenu = new RightMenu(new List<ExplorerEntity> { });
            }

            if (_isLeftRight)
            {

                _rightMenu.ClearItems();
                _rightMenu.SetNewItems(new List<ExplorerEntity>(
                    DirectoryService.GetInnerFromDirectory(
                    fullPath)
                    .Select(x => GetType(x))
                ));
                _rightMenu.SetCurrentPosition(fullPath);

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
                _leftMenu.SetCurrentPosition(fullPath);
                isPrinted = true;
            }

            ClearSideOfMenu(!_isLeftRight);


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

        public static ExplorerEntity GetType(FileSystemInfo item)
        {
            if (item is DirectoryInfo)
            {
                return new DirectoryEntity((item as DirectoryInfo)!);
            }

            if (item is FileInfo)
            {
                if (item.Extension == "txt")
                {
                    return new TextFileEntity((item as FileInfo)!);
                }

                return new FileEntity((item as FileInfo)!);
            }

            return null;
        }
    }
}
