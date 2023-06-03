using Microsoft.VisualBasic;
using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTest();
        }

        static void UnitTest()
        {
            Deque<string> deque = new Deque<string>(5);
            /// output:
            /// string1
            /// string2
            /// string3
            /// string4
            /// string5
            deque.addFirst("string3");
            deque.addLast("string4");
            deque.addFirst("string2");
            deque.addLast("string5");
            deque.addFirst("string1");


            var it = deque.iterator();
            while (it.HasNext)
            {
                Console.WriteLine(it.MoveNext());
            }

            Console.WriteLine("====================");
            /// output:
            /// string2
            deque.removeLast();
            deque.removeLast();
            deque.removeFirst();
            deque.removeLast();
            
            it = deque.iterator();
            while (it.HasNext)
            {
                Console.WriteLine(it.MoveNext());
            }

            Console.WriteLine("=======");
            /// string-1
            /// string0
            /// string1
            /// string2
            /// string4
            deque.addFirst("string1");
            deque.addLast("string4");
            deque.addFirst("string0");
            deque.addFirst("string-1");

            it = deque.iterator();
            while (it.HasNext)
            {
                Console.WriteLine(it.MoveNext());
            }
        }
    }

    public class Deque<Item> : IIterator<Item>
    {
        public bool HasNext => (this._tempHigh - this._tempLow) + 1  != this._sizeOfArray;
        public Item[] items;
        private int _sizeOfArray;
        private int _low;
        private int _high;


        private int _tempLow;
        private int _tempHigh;
        // construct an empty deque
        public Deque(int sizeOfArray)
        {
            this._sizeOfArray = sizeOfArray;
            this._low = 0;
            this._high = sizeOfArray-1;

            this._tempHigh = this._high;
            this._tempLow = this._low;

            items = new Item[sizeOfArray];
        }
        // is the deque empty?
        public bool isEmpty()
        {
            return (this._high - this._low) == _sizeOfArray - 1;
        }
        // return the number of items on the deque
        public int size()
        {
            return this._sizeOfArray;
        }
        // add the item to the front
        public void addFirst(Item item)
        {
            if(this._low <= this._high)
            {
                this.items[_low] = item;
                _low++;
            }
        }
        // add the item to the back
        public void addLast(Item item)
        {
            if (this._low <= this._high)
            {
                int ind = this._high >= this._sizeOfArray ? this._sizeOfArray - this._high : this._high;
                this.items[Math.Abs(ind)] = item;
                _high--;
            }
        }

        // remove and return the item from the front
        public Item removeFirst()
        {
            if (!this.isEmpty())
            {
                if (this._low > 0)
                {
                    int ind = this._low;
                    this._low--;
                    return items[ind];
                }

                if (Math.Abs(this._low) < this._sizeOfArray - this._high)
                {
                    int ind = this._sizeOfArray - 1 + this._low;
                    this._low--;
                    return this.items[ind];
                }
            }
            return default!;
        }
        // remove and return the item from the back
        public Item removeLast()
        {
            if (!this.isEmpty())
            {
                if (this._high < _sizeOfArray + (this._low > 0 ? 0 : this._low) - 1)
                {
                    this._high++;
                    int ind = this._high;
                    return items[ind];
                }

                if (this._low >= 0)
                {
                    this._high++;
                    int ind = this._sizeOfArray - this._high;
                    return this.items[Math.Abs(ind)];
                }
            }
            return default!;
        }
        // return an iterator over items in order from front to back
        public IIterator<Item> iterator()
        {
            this._tempHigh = this._high;
            this._tempLow = this._low;
            return this;
        }
        public Item MoveNext()
        {
            if (_tempLow > 0)
            {
                this._tempLow--;
                var item = items[this._tempLow];
                return item;
            }

            if (Math.Abs(this._tempLow) < this._sizeOfArray - this._tempHigh)
            {
                var item = items[this._sizeOfArray - 1 + this._tempLow];
                this._tempLow--;
                return item;
            }
            else
            {
                this._tempHigh = this._sizeOfArray - 1;

            }
            return default!;
        }
    }
    public interface IIterator<T>
    {
        bool HasNext { get; }
        T MoveNext();
    }


}

