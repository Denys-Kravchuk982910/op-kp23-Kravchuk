using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tools
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
            
        }

        public T this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        protected T GetValue(int key)
        {
            return null;
        }

        protected void SetValue(int key, T value)
        {
            
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
            return null;
        }

        public CustomItem<T> GetNext() 
        {
            return null;
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
