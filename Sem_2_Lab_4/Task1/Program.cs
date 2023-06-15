using System;
using System.Security.Cryptography.X509Certificates;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> table = new HashTable<string, int>();

            //table.Add("key2", "key2");
            //table.Add("key3", "key3");
            //table.Add("key150", "key3");
            //table.Add("key1", "key1");
            //table.Add("key4", "key4");

            table.Add("key2", 2);
            table.Add("k2ey", 3);
            table.Add("key150", 150);
            table.Add("key1", 1);
            table.Add("key4", 4);

           
        }
    }

    public class HashTable<KItem, VItem>
    {
        protected int _actuallSize;
        protected int _capacity;
        protected HashItem<KItem, VItem>[] _items;
        public HashTable()
        {
            this._capacity = 10;
            this._actuallSize = 0;
            this._items = new HashItem<KItem, VItem>[this._capacity];
        }

        public HashTable(int intialCapacity)
        { 
            this._capacity = intialCapacity*2;
            this._actuallSize = 0;
            this._items = new HashItem<KItem, VItem>[this._capacity];
        }

        public virtual void Add(KItem key, VItem value)
        {
            if (this._actuallSize < this._capacity/2)
            {
                int? item = key?.GetHashCode();
                HashItem<KItem, VItem> hashItem =
                    new HashItem<KItem, VItem>(key, value);
                if (item != null)
                {
                    this._actuallSize++;
                    int index = Math.Abs(item.Value % this._capacity);

                    int i = 1;

                    while (this._items[index] != null && !this._items[index].Key!.Equals(key))
                    {
                        index = Math.Abs((index + (int)Math.Pow(i, 2)) % this._capacity);
                        i++;
                    }

                    this._items[index] = hashItem;
                }


            }

        }

        public virtual void Remove(KItem key)
        {
            if (this._actuallSize > 0)
            {
                int? item = key?.GetHashCode();
                if (item != null)
                {
                    this._actuallSize--;
                    int index = Math.Abs(item.Value % this._capacity);

                    int i = 1;

                    while (this._items[index] != null && !this._items[index].Key!.Equals(key))
                    {
                        index = Math.Abs((index + (int)Math.Pow(i, 2)) % this._capacity);
                        i++;
                    }

                    this._items[index] = null!;
                }
            }
        }

        public VItem Get(KItem key)
        {
            int? item = key?.GetHashCode();
            if (item != null)
            {
                int index = Math.Abs(item.Value % this._capacity);

                int i = 1;

                while (!this._items[index].Key!.Equals(key))
                {
                    index = Math.Abs((index + (int)Math.Pow(i, 2)) % this._capacity);
                    i++;
                }

                return _items[index].Value;
            }

            return default!;
        }

        public bool Contains(VItem value)
        {
            bool isFlag = false;

            for (int i = 0; i < _items.Length; i++)
            {
                if (this._items[i] != null 
                    && this._items[i].Value!.Equals(value))
                {
                    return true;
                }
            }

            return isFlag;
        }

        public void Clear()
        {
            this._items = new HashItem<KItem, VItem>[this._capacity];
        }

        public int Size()
        {
            return this._capacity/2;
        }



        public class HashItem<KItem, VItem>
        {
            public KItem Key { get; private set; }
            public VItem Value { get; private set; }

            public HashItem(KItem key, VItem value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}