using System;

namespace Task2 
{
    class Program
    {
        static void Main(string[] args) 
        {
            RandomizedQueue<string> randomizedQueue = new RandomizedQueue<string>();

            randomizedQueue.enqueue("string1");
            randomizedQueue.enqueue("string2");
            randomizedQueue.enqueue("string3");
            randomizedQueue.enqueue("string4");
            randomizedQueue.enqueue("string5");
            randomizedQueue.enqueue("string6");
            randomizedQueue.enqueue("string7");


            IIterator<string> iterator = randomizedQueue.iterator();

            while (iterator.HasNext)
            {
                Console.WriteLine(iterator.MoveNext());
            }

            Console.WriteLine("============dequeues==========");

            Console.WriteLine(randomizedQueue.dequeue());
            Console.WriteLine(randomizedQueue.dequeue());
            Console.WriteLine(randomizedQueue.dequeue());

            Console.WriteLine("==============================");
            Console.WriteLine("=============samples==========");

            Console.WriteLine(randomizedQueue.sample());
            Console.WriteLine(randomizedQueue.sample());
            Console.WriteLine(randomizedQueue.sample());
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
        public bool HasNext => _currentItem != null;
        public Node<Item> _collection;
        private Node<Item> _currentItem;
        private Random _random;
        // construct an empty randomized queue
        public RandomizedQueue()
        {
            this._collection = null!;
            this._currentItem = null!;
            _random = new Random();
        }
        // is the randomized queue empty?
        public bool isEmpty()
        {
            return !this.HasNext;
        }
        // return the number of items on the randomized queue
        public int size()
        {
            int counter = 0;
            this._currentItem = this._collection;
            while (this.HasNext)
            {
                counter++;
                _currentItem = _currentItem.Next;
            }


            _currentItem = _collection;
            return counter;
        }
        // add the item
        public void enqueue(Item item)
        {
            int rand = _random.Next(10);

            if(rand <= 5)
            {
                //first
                if (_collection != null)
                {
                    Node<Item> newItem = new Node<Item>();
                    newItem.Value = item;
                    newItem.Next = this._collection;
                    this._collection = newItem;
                    this._currentItem = this._collection;
                    return;
                }
                this._collection = new Node<Item>();
                this._currentItem = this._collection;
                this._collection!.Value = item;
                this._collection.Next = null!;
            }
            else
            {
                //last
                _currentItem = this._collection;
                if (_collection != null)
                {
                    Node<Item> newItem = new Node<Item>();
                    newItem.Value = item;

                    var chItem = _currentItem;
                    while (this.HasNext)
                    {
                        chItem = _currentItem;
                        _currentItem = _currentItem.Next;
                    }

                    chItem.Next = newItem;
                    _currentItem = _collection;
                    return;
                }

                this._collection = new Node<Item>();
                this._currentItem = this._collection;
                this._collection!.Value = item;
                this._collection.Next = null!;
            }
        }
        // remove and return a random item
        public Item dequeue()
        {
            int rand = _random.Next(10);

            if (rand <= 5)
            {
                //first
                if (_collection != null)
                {
                    var chItem = this._collection.Value;
                    this._currentItem = _collection.Next;
                    this._collection = _collection.Next;
                    return chItem;
                }
                return default!;
            }
            else
            {
                //last
                if (_collection != null)
                {
                    int size = this.size() - 2;
                    for (int i = 0; i < size; i++)
                    {
                        _currentItem = _currentItem.Next;
                    }

                    Item val = _currentItem.Next.Value;

                    _currentItem.Next = null!;
                    _currentItem = _collection;

                    if (size+2 == 1)
                    {
                        _collection = null!;
                        _currentItem = null!;
                    }
                    return val;
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
                if (_collection != null)
                {
                    var chItem = this._collection.Value;
                    return chItem;
                }
                return default!;
            }
            else
            {
                //last
                if (_collection != null)
                {
                    int size = this.size() - 2;
                    for (int i = 0; i < size; i++)
                    {
                        _currentItem = _currentItem.Next;
                    }

                    Item val = _currentItem.Next.Value;
                    _currentItem = _collection;
                    return val;
                }

                return default!;
            }
        }
        // return an independent iterator over items in random order
        public IIterator<Item> iterator()
        {
            return this;
        }

        public Item MoveNext()
        {
            var val = this._currentItem;
            this._currentItem = this._currentItem.Next;
            return val.Value;
        }
    }

    public interface IIterator<T>
    {
        bool HasNext { get; }
        T MoveNext();
    }

    public class Node<T>
    {
        public T Value { get; set; } = default!;
        public Node<T> Next { get; set; } = null!;
    }

}

