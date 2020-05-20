using System;

namespace FunWithLists
{
    public class Program
    {
        /*
         *  Implement the method indexOf, which accepts a linked list (head)
         *  and a value, and returns the index (zero-based) of the first ocurrence of that
         *  value if it exists, or -1 otherwise.
         */
        public static void Main(string[] args)
        {
            var emptyList = new NodeList();
            emptyList.PrintList();
            Console.WriteLine();

            var listOfOne = new NodeList("List of One");
            listOfOne.Add("First and Only Item");
            listOfOne.PrintList();
            var index = listOfOne.IndexOf("First and Only Item");

            var listOfMany = new NodeList("List of Many");
            listOfMany.Add("First Item");
            listOfMany.Add("Second Item");
            listOfMany.Add("Third Item");
            listOfMany.Add("Fourth Item");
            listOfMany.Add("Fifth Item");
            listOfMany.Add("Sixth Item");
            listOfMany.PrintList();
            index = listOfMany.IndexOf("Fourth Item");
            Console.ReadLine();
        }
    }

    public class NodeList
    {
        public Node Head { get; set; }

        private string ListTitle { get; set; }

        public NodeList()
        {
            ListTitle = "No Title";
        }

        public NodeList(string title)
        {
            ListTitle = title;
        }

        public void Add(Node node)
        {
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                var ptr = Head;

                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }

        }

        public void Add(string data)
        {
            var newNode = new Node(data);
            Add(newNode);
        }

        public int IndexOf(string data)
        {
            var index = -1;
            var ptr = Head;
            while (ptr != null)
            {
                index++;
                if (ptr.Text == data)
                {
                    return index;
                }

                ptr = ptr.Next;
            }
            return index;
        }

        public void PrintList()
        {
            Console.WriteLine(ListTitle + ":");
            var ptr = Head;
            if (ptr != null)
            {
                while (ptr != null)
                {
                    Console.WriteLine(ptr.Text);
                    ptr = ptr.Next;
                }
                Console.WriteLine("End of List");
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
            Console.WriteLine();
        }
    }

    public class Node
    {
        public Node(string text)
        {
            Next = null;
            Text = text;
        }
        public Node Next { get; set; }
        public string Text { get; set; }
    }
}
