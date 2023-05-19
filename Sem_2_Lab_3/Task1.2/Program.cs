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
            
        }
    }

    public class Deque<Item> : IIterator<Item>
    {
        public bool HasNext => (this._high - this._low) + 1 != this._sizeOfArray;
        public Item[] items;
        private int _sizeOfArray;
        private int _low;
        private int _high;
        // construct an empty deque
        public Deque(int sizeOfArray)
        {
            this._sizeOfArray = sizeOfArray;
            this._low = 0;
            this._high = sizeOfArray-1;
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
            if(this._low < this._high)
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

                if (this._high - this._low < this._sizeOfArray)
                {
                    int ind = this._high + this._low;
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
                    int ind = this._high;
                    this._high++;
                    return items[ind];
                }

                if (this._low >= 0)
                {
                    int ind = this._sizeOfArray - this._high-1;
                    this._high++;
                    return this.items[Math.Abs(ind)];
                }
            }
            return default!;
        }
        // return an iterator over items in order from front to back
        public IIterator<Item> iterator()
        {
            return this;
        }
        public Item MoveNext()
        {
            if(_low > 0)
            {
                var item = items[this._low-1];
                this._low--;
                return item;
            }

            if(Math.Abs(this._low) < this._high + this._low + 1)
            {
                var item = items[this._sizeOfArray-1+this._low];
                this._low--;
                return item;
            }else
            {
                this._high = this._sizeOfArray - 1;
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

