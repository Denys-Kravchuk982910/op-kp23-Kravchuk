using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args) 
        {
            
        }
    }

    public class Deque<Item> : IIterator<Item>
    {
        public bool HasNext => throw new NotImplementedException();
        private Node<Item> _collection = null;
        // construct an empty deque
        public Deque()
        {
            
        }
        
        // is the deque empty?
        public bool isEmpty()
        {
            return true;    
        }
        
        // return the number of items on the deque
        public int size()
        {
            return 0;
        }
        // add the item to the front
        public void addFirst(Item item)
        {
            
        }
        // add the item to the back
        public void addLast(Item item)
        {

        }
        
        // remove and return the item from the front
        public Item removeFirst()
        {
            return default;
        }
        // remove and return the item from the back
        public Item removeLast()
        {
            return default;
        }
        // return an iterator over items in order from front to back
        public IIterator<Item> iterator()
        {
            return default;
        }
        // unit testing (required)
        public static void main(String[] args)
        {

        }
        public Item MoveNext()
        {
            throw new NotImplementedException();
        }
    }
    public interface IIterator<T>
    {
        bool HasNext { get; }
        T MoveNext();
    }

    public class Node<T>
    {
        public T Value { get; set; } = default;
        public Node<T> Next { get; set; } = null;
    }


}
