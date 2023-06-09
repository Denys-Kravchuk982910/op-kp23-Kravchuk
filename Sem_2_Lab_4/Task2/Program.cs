using System;
using System.Text;
using Task1;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;


            CustomDictionary<string, string> ht =
                new CustomDictionary<string, string>(10);

            ht.Add("Hello", "Привіт");
            ht.Add("Deserve", "Заслуговувати");
            ht.Add("Oblige", "Зобов'язувати");
            ht.Add("Accept", "Державні виплати");
            ht.Add("Deny", "Заперечувати");


            Console.WriteLine(ht["Oblige"]);
            Console.WriteLine(ht["Hello"]);
            Console.WriteLine(ht["Accept"]);

        }
    }


    class CustomDictionary<KItem, VItem> : HashTable<KItem, VItem>
    {
        public CustomDictionary(int initialCapactiy) : base(initialCapactiy)
        {

        }

        public override void Add(KItem key, VItem value)
        {
            if (this._actuallSize < this._capacity / 2)
            {
                int? item = this.CustomGetHashCode(key);
                HashItem<KItem, VItem> hashItem =
                    new HashItem<KItem, VItem>(key, value);
                if (item != null)
                {
                    this._actuallSize++;
                    int index = GetIndex(item.Value, key);

                    this._items[index] = hashItem;
                }


            }
        }

        public override void Remove(KItem key)
        {
            if (this._actuallSize > 0)
            {
                int? item = this.CustomGetHashCode(key);
                if (item != null)
                {
                    this._actuallSize--;
                    int index = GetIndex(item.Value, key);

                    this._items[index] = null!;
                }
            }
        }

        public int CustomGetHashCode(KItem key)
        {
            string kItem = key?.ToString()!;
            double index = 0;
            double koef = 1;
            if(kItem != null)
            {
                for (int i = 0; i < kItem.Length; i++)
                {
                    index += koef * kItem[i];
                    koef *= 0.5;
                }
                return (int)index;
            }


            return -1;
        }

        public VItem this[KItem key]
        {
            get => this._items[this.GetIndex(this.CustomGetHashCode(key), key)].Value;
        } 


        public int GetIndex (int hash, KItem key)
        {
            int index = Math.Abs(hash % this._capacity);

            int i = 1;

            while (this._items[index] != null && !this._items[index].Key!.Equals(key))
            {
                index = Math.Abs((index + (int)Math.Pow(i, 2)) % this._capacity);
                i++;
            }

            return index;
        }
    }
}
