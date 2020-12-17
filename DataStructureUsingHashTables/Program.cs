using System;

namespace DataStructureUsingHashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMapNode<string, int> myMapNode = new MyMapNode<string, int>(5);
            string sentence="To be or not to be";
            string[] words=sentence.ToLower().Split(" ");
            foreach(string word in words)
            {
               int value= myMapNode.Get(word);
                if (value == 0)
                    value = 1;
                else
                    value = value + 1;
                    myMapNode.Add(word, value);
            }
            int frequency= myMapNode.Get("be");
            Console.WriteLine("Frequency of word in sentence = " + frequency);

            sentence = "Paranoids are not paranoid because they are paranoid but because" +
            " they keep putting themselves deliberately into paranoid avoidable situations";
            words = sentence.ToLower().Split(" ");
            foreach (string word in words)
            {
                int value = myMapNode.Get(word);
                if (value == 0)
                    value = 1;
                else
                    value = value + 1;
                myMapNode.Add(word, value);
            }
            frequency = myMapNode.Get("paranoid");
            Console.WriteLine("Frequency of word in paragraph = " + frequency);

            myMapNode.Remove("avoidable");



        }
    }
}
