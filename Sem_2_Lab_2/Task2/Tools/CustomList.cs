using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tools
{
    public class CustomList<T> where T : class
    {
        private CustomItem<T> current;
        private CustomItem<T> first;
        private int _count;

        public CustomList()
        {
            current = null;
            first = null;
            _count = 0;
        }

        public void Add(T newItem)
        {
            CustomItem<T> item = new CustomItem<T>(newItem);

            if (current != null)
            {
                item = current.SetNext(item);
            }

            if (first == null)
            {
                first = item;
            }

            current = item;
            _count++;
        }

        public T this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        protected T GetValue(int key)
        {
            var link = first;
            if (key < 0 || key >= this._count)
            {
                throw new ArgumentOutOfRangeException("Key", "Key is bigger than size of collection!");
            }

            for (int i = 0; i < key; i++)
            {
                link = link.GetNext();
            }
            return link.GetValue();
        }

        protected void SetValue(int key, T value)
        {
            var link = first;
            if (key < 0 || key >= this._count)
            {
                throw new ArgumentOutOfRangeException("Key", "Key is bigger than size of collection!");
            }

            for (int i = 0; i < key; i++)
            {
                link = link.GetNext();
            }

            link.SetValue(value);
        }

        public int Count  {
            get => this._count;
            private set => this._count = value;
        }


    }

    public class CustomItem<T> where T : class
    {
        private CustomItem<T> _prev;
        private CustomItem<T> _next;
        private T _value;

        public CustomItem()
        {
            this._value = null;
            this._prev = null;
            this._next = null;
        }

        public CustomItem(T value)
        {
            this._value = value;
            this._prev = null;
            this._next = null;
        }

        public CustomItem<T> SetNext(CustomItem<T> item) 
        {
            this._next = item;
            item._prev = this;
            return item;
        }

        public CustomItem<T> GetNext() 
        {
            return this._next;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public T GetValue() 
        {
            return this._value;
        }

        public void SetValue(T value) 
        {
            this._value = value;
        }

    }
}
