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
            Deque<string> queue = new Deque<string>();

            //Added in the range:
            /// string1
            /// string2
            /// string3
            /// string4
            /// string5
            /// string6
            queue.addFirst("string3");
            queue.addFirst("string2");
            queue.addFirst("string1");
            queue.addLast("string4");
            queue.addLast("string5");
            queue.addLast("string6");

            /// Removed Last Item
            if (queue.removeLast() == "string6")
            {
                Console.WriteLine("String6 was removed!");
            }
            /// Removed First Item
            if (queue.removeFirst() == "string1")
            {
                Console.WriteLine("String1 was removed!");
            }


            if (queue.size() == 4)
            {
                Console.WriteLine("The size was shown correctly!");
            }

            if (queue.isEmpty() == false)
            {
                Console.WriteLine("The empty property showed false");
            }

            // The strings were shown in such order:
            /// string2
            /// string3
            /// string4
            /// string5
            /// 
            Console.WriteLine("=======================");
            Console.WriteLine("Testing iterator:");
            IIterator<string> it = queue.iterator();
            while (it.HasNext)
            {
                Console.WriteLine(it.MoveNext());
            }
        }
    }

    public class Deque<Item> : IIterator<Item>
    {
        public bool HasNext => _currentItem != null;
        public Node<Item> _collection;
        private Node<Item> _currentItem;
        // construct an empty deque
        public Deque()
        {
            this._collection = null!;
            this._currentItem = null!;
        }
        
        // is the deque empty?
        public bool isEmpty()
        {
            return !this.HasNext;    
        }
        
        // return the number of items on the deque
        public int size()
        {
            int counter = 0;

            while(this.HasNext)
            {
                counter++;
                _currentItem = _currentItem.Next;
            }


            _currentItem = _collection;
            return counter;
        }
        // add the item to the front
        public void addFirst(Item item)
        {
            //_currentItem = this._collection;
            if (_collection != null)
            {
                Node<Item> newItem = new Node<Item>();
                newItem.Value = item;
                newItem.Next = this._collection;
                this._collection = newItem;
                return;
            }
            this._collection = new Node<Item>();
            this._currentItem = this._collection;
            this._collection!.Value = item;
            this._collection.Next = null!;
        }
        // add the item to the back
        public void addLast(Item item)
        {
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
        
        // remove and return the item from the front
        public Item removeFirst()
        {
            if (_collection != null) 
            {
                var chItem = this._collection.Value;
                this._currentItem = _collection.Next;
                this._collection = _collection.Next;
                return chItem;
            }
            return default!;
        }

        // remove and return the item from the back
        public Item removeLast()
        {
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

                if(size == 1)
                {
                    _collection = null!;
                    _currentItem = null!;
                } 
                return val;
            }

            return default!;
        }
        // return an iterator over items in order from front to back
        public IIterator<Item> iterator()
        {
            this._currentItem = this._collection;
            return this;
        }
        // unit testing (required)
        public static void main(String[] args)
        {
            
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
