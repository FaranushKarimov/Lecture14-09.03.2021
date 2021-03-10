using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson14_09._03._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyList implementation
            MyList<int> myList = new MyList<int>(10);
            myList.AddItem(5);
            myList.AddItem(5);
            myList.AddItem(5);
            foreach (var t in myList)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine(myList.length);
            Console.WriteLine(myList.GetItem(2));

            // MyDictionary implementation 
            MyDictionary<int, string> myDictionary = new MyDictionary<int, string>(10);
            myDictionary.AddItem(5, "Faranush");
            Console.WriteLine(myDictionary.Length);

            Console.WriteLine(myDictionary.GetItem(5));

            foreach (Result<int, string> result in myDictionary.GetValues())
            {
                Console.WriteLine(result.Key + " " + result.Value);
            }

            Console.WriteLine("\n\nPlease press any key to continue...");
            Console.ReadKey();
        }



    }

    class MyDictionary<TKey, TValue>
    {
        private MyList<TKey> keys;
        private MyList<TValue> values;
        private int size = 0;
        public MyDictionary(int size)
        {
            this.size = size;
            keys = new MyList<TKey>(size);
            values = new MyList<TValue>(size);
        }
        public int Length
        {
            get
            {
                return size;
            }
        }
        public void AddItem(TKey key, TValue value)
        {
            keys.AddItem(key);
            values.AddItem(value);
        }
        public TValue GetItem(TKey key)
        {
            object notFound = new object();
            for (int i = 0; i < keys.length; i++)
            {
                var findKey = keys.GetItem(i);
                if (findKey.Equals(key))
                {
                    return values.GetItem(i);
                }
            }
            return (TValue)notFound;
        }
        public IEnumerable GetValues()
        {
            Result<TKey, TValue> result;
            for (int i = 0; i < keys.length; i++)
            {
                result = new Result<TKey, TValue>(keys.GetItem(i), values.GetItem(i));
                yield return result;
            }
        }
    }
    class Result<TKey, TValue>
    {
        public TValue Value { get; set; }
        public TKey Key { get; set; }
        public Result(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }


    class MyList<T>
    {
        private int size = 0;
        private int curIndex = 0;
        private T[] items;
        public MyList(int size)
        {
            this.size = size;
            items = new T[size];
        }
        public void AddItem(T item)
        {
            items[curIndex] = item;
            curIndex++;
        }
        public bool Equals(T compare, int index)
        {
            if (items[index].Equals(compare))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public T GetItem(int position)
        {
            if (position > 0 && position < items.Length)
                return items[position];
            else
                return items[0];
        }
        public int length
        {
            get
            {
                return size;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < items.Length; i++)
            {

                yield return items[i];
            }
        }
    }


    class Items
    {
        public string name { get; set; }
        public Items(string name)
        {
            this.name = name;
        }
    }
    class Shop
    {
        public List<Items> items = new List<Items>();
        public Shop()
        {

        }
        public void AddItem(Items item)
        {
            items.Add(item);
        }
        public IEnumerable GetItems(int max)
        {

            for (int i = 0; i < max; i++)
            {
                if (i == items.Count)
                {
                    yield break;
                }
                else
                {
                    yield return items[i];
                }
            }
        }
    }



    class Book
    {
        public string name { get; set; }
        public Book(string name)
        {
            this.name = name;
        }
    }
    class Library
    {
        public List<Book> books = new List<Book>();
        public Library()
        {

        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public int length
        {
            get { return books.Count; }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < books.Count; i++)
            {
                yield return books[i];
            }
        }
    }

    class Person
    {
        public string name { get; set; }
        public Person(string name)
        {
            this.name = name;
        }
    }
}
