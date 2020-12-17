using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureUsingHashTables
{
    public class MyMapNode<k,v>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<k, v>>[] items;

        /// <summary>
        /// Parameterized Constructor to Initializes a new instance of the <see cref="MyMapNode{k, v}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<k, v>>[size];
        }

        /// <summary>
        /// Get the array position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>position</returns>
        public int GetArrayPosition(k key)
        {
            int poistion = key.GetHashCode() % size;
            return Math.Abs(poistion);
        }

        /// <summary>
        /// Get the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>value if get key matched</returns>
        public int Get(k key)
        {
            int poistion = GetArrayPosition(key);
            LinkedList<KeyValue<k, v>> linkedList = GetLinkedList(poistion);
            foreach (KeyValue<k, v> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    string s= item.Value.ToString();
                    return int.Parse(s);
                }
            }
            return 0;
        }

        /// <summary>
        /// Get the linked list.
        /// </summary>
        /// <param name="poistion">The poistion.</param>
        /// <returns>linked list</returns>
        public LinkedList<KeyValue<k, v>> GetLinkedList(int poistion)
        {
            LinkedList<KeyValue<k, v>> linkedList = items[poistion];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<k, v>>();
                items[poistion] = linkedList;
            }
            return linkedList;
        }

        /// <summary>
        /// struct for setter getter
        /// </summary>
        /// <typeparam name="k"></typeparam>
        /// <typeparam name="v"></typeparam>
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }

        /// <summary>
        /// Gets the frequency of words.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>split</returns>
        public int getFrequencyOfWords(k key)
        {
            int poistion=GetArrayPosition(key);
            LinkedList<KeyValue<k, v>> linkedList=GetLinkedList(poistion);
            foreach(KeyValue<k, v>items in linkedList)
            {
                if (items.Key.Equals(key))
                {
                    string s=items.Value.ToString();
                    return s.Split(" ").Length;
                }
            }
            return 0;
        }

        /// <summary>
        /// Adds the specified key with value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(k key, v value)
        {
            int poistion = GetArrayPosition(key);
            LinkedList<KeyValue<k, v>> linkedList = GetLinkedList(poistion);
            KeyValue<k, v> item = new KeyValue<k, v>() { Key = key, Value = value, };
            linkedList.AddFirst(item);
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(k key)
        {
            int poistion = GetArrayPosition(key);
            LinkedList<KeyValue<k, v>> linkedList = GetLinkedList(poistion);
            bool itemFound = false;
            KeyValue<k, v> foundItem = default(KeyValue<k, v>);
            foreach(KeyValue<k,v>item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                Console.WriteLine(key + " removed ");
                linkedList.Remove(foundItem);
            }
        }
    }
}

