using System;

namespace Task2 
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomizedQueue<string> randomizedQueue = new RandomizedQueue<string>(5);

            randomizedQueue.enqueue("string1");
            randomizedQueue.enqueue("string2");
            randomizedQueue.enqueue("string3");
            randomizedQueue.enqueue("string4");
            randomizedQueue.enqueue("string5");


            IIterator<string> iterator = randomizedQueue.iterator();

            while (iterator.HasNext)
            {
                Console.WriteLine(iterator.MoveNext());
            }


            Console.WriteLine("=============samples==========");


            Console.WriteLine(randomizedQueue.sample());
            Console.WriteLine(randomizedQueue.sample());
            Console.WriteLine(randomizedQueue.sample());

            Console.WriteLine("==============================");

            Console.WriteLine("=============dequees==========");

            Console.WriteLine(randomizedQueue.dequeue());
            Console.WriteLine(randomizedQueue.dequeue());
            Console.WriteLine(randomizedQueue.dequeue());
            Console.WriteLine("==============================");

            Console.WriteLine("=============samples==========");

            Console.WriteLine(randomizedQueue.sample());
            Console.WriteLine(randomizedQueue.sample());
            Console.WriteLine(randomizedQueue.sample());

            Console.WriteLine("==============================");

            Console.WriteLine("==============================");

            iterator = randomizedQueue.iterator();

            while (iterator.HasNext)
            {
                Console.WriteLine(iterator.MoveNext());
            }

        }
    }

    public class RandomizedQueue<Item> : IIterator<Item>
    {
        public bool HasNext => (this._tempHigh - this._tempLow)+1 != this._sizeOfArray;
        public Item[] items;
        private int _sizeOfArray;
        private int _low;
        private int _high;

        private int _tempLow;
        private int _tempHigh;


        private Random _random;
        // construct an empty randomized queue
        public RandomizedQueue(int sizeOfArray)
        {
            _random = new Random();
            this._sizeOfArray = sizeOfArray;
            this._low = 0;
            this._high = sizeOfArray - 1;

            this._tempLow = 0;
            this._tempHigh = sizeOfArray - 1;

            items = new Item[sizeOfArray];
        }
        // is the randomized queue empty?
        public bool isEmpty()
        {
            return (this._high - this._low) == _sizeOfArray - 1;
        }
        // return the number of items on the randomized queue
        public int size()
        {
            return this._sizeOfArray;
        }
        // add the item
        public void enqueue(Item item)
        {
            int rand = _random.Next(10);

            if(rand <= 5)
            {
                //first
                if (this._low < this._high+1)
                {
                    this.items[_low] = item;
                    _low++;
                }
            }
            else
            {
                //last
                if (this._low-1 < this._high)
                {
                    int ind = this._high >= this._sizeOfArray ? this._sizeOfArray - this._high : this._high;
                    this.items[Math.Abs(ind)] = item;
                    _high--;
                }
            }

        }
        // remove and return a random item
        public Item dequeue()
        {
            int rand = _random.Next(10);

            if (rand <= 5)
            {
                //first
                if (!this.isEmpty())
                {
                    if (this._low > 0)
                    {
                        this._low--;
                        int ind = this._low;
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
            else
            {
                //last
                if (!this.isEmpty())
                {
                    if (this._high < _sizeOfArray + (this._low > 0 ? 0 : this._low)-1)
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
        }
        // return a random item (but do not remove it)
        public Item sample()
        {
            int rand = _random.Next(10);

            if (rand <= 5)
            {
                //first
                if (!this.isEmpty())
                {
                    if (this._low > 0)
                    {
                        int ind = this._low-1;
                        return items[ind];
                    }

                    if (Math.Abs(this._low) < this._sizeOfArray - this._high)
                    {
                        int ind = this._sizeOfArray - 1 + this._low-1;
                        return this.items[ind];
                    }
                }
                return default!;
            }
            else
            {
                //last
                if (!this.isEmpty())
                {
                    if (this._high < _sizeOfArray + (this._low > 0 ? 0 : this._low) - 1)
                    {
                        int ind = this._high + 1;
                        return items[ind];
                    }

                    if (this._low >= 0)
                    {
                        int ind = this._sizeOfArray - (this._high + 1);
                        return this.items[Math.Abs(ind)];
                    }
                }
                return default!;
            }
        }
        // return an independent iterator over items in random order
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
                var item = items[this._tempLow - 1];
                this._tempLow--;
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

