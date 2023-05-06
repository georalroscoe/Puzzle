using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeClass
{
    class Node
    {
        public Tuple<int, string> Value { get; set; }
        public List<Node> Children { get; set; }
        public int[] ArrayState { get; set; }
        public Node Parent { get; set; }
        public bool IsSorted { get; set; }
        

        public Node(Tuple<int, string> value, int[] arrayState)
        {
            Value = value;
            Children = new List<Node>();
            ArrayState = arrayState;
           
        }

        public void AddChild(Node child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Child node cannot be null");
            }

            if (child.Parent == this)
            {
                throw new ArgumentException("Cannot add child node as it's already a child of this node.");
            }

            child.Parent = this;
            Children.Add(child);
        }
        public void getPathway()
        {
            List<int> pathway = new List<int>();
            Node currentNode = this;
            this.IsSorted = true;


            while (currentNode != null)
            {
                pathway.Add(currentNode.Value.Item1);
                currentNode = currentNode.Parent;
            }

            pathway.Reverse();
            Console.Write("Pathway: ");
            for (int i = 0; i < pathway.Count; i++)
            {
                Console.Write(pathway[i]);
                if (i < pathway.Count - 1)
                {
                    Console.Write(" -> ");
                }
            }
            Console.WriteLine();



        }
        public void FillTreeValues(int[] array, Queue<Node> nodeQueue, int[] result)
        {


            int[] unchanged = new int[9];
            for (int i = 0; i < 9; i++)
            {
                unchanged[i] = array[i];
            }
            int[] unchanged2 = new int[9];
            for (int i = 0; i < 9; i++)
            {
                unchanged2[i] = array[i];
            }
            int[] unchanged3 = new int[9];
            for (int i = 0; i < 9; i++)
            {
                unchanged3[i] = array[i];
            }



            int value = Value.Item1;
            int? parentValue = this.Parent?.Value.Item1;

            if (value == 0)
            {
                
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(3, "down"), sortArray(array, 0, "down")));



                }
                if (parentValue != 1)
                {
                    this.AddChild(new Node(new Tuple<int, string>(1, "right"), sortArray(unchanged, 0, "right")));

                }
            }
            else if (value == 1)
            {
                if (parentValue != 0)
                {
                    this.AddChild(new Node(new Tuple<int, string>(0, "left"), sortArray(array, 1, "left")));

                }
                if (parentValue != 2)
                {
                    this.AddChild(new Node(new Tuple<int, string>(2, "right"), sortArray(unchanged, 1, "right")));

                }
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "down"), sortArray(unchanged2, 1, "down")));

                }
            }
            else if (value == 2)
            {
                if (parentValue != 1)
                {
                    this.AddChild(new Node(new Tuple<int, string>(1, "left"), sortArray(array, 2, "left")));

                }
                if (parentValue != 5)
                {
                    this.AddChild(new Node(new Tuple<int, string>(5, "down"), sortArray(unchanged, 2, "down")));

                }
            }
            else if (value == 3)
            {
                if (parentValue != 0)
                {
                    this.AddChild(new Node(new Tuple<int, string>(0, "up"), sortArray(array, 3, "up")));

                }
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "right"), sortArray(unchanged, 3, "right")));

                }
                if (parentValue != 6)
                {
                    this.AddChild(new Node(new Tuple<int, string>(6, "down"), sortArray(unchanged2, 3, "down")));

                }
            }
            else if (value == 4)
            {
                if (parentValue != 3)
                {
                    this.AddChild(new Node(new Tuple<int, string>(3, "left"), sortArray(array, 4, "left")));

                }
                if (parentValue != 5)
                {
                    this.AddChild(new Node(new Tuple<int, string>(5, "right"), sortArray(unchanged, 4, "right")));

                }
                if (parentValue != 7)
                {
                    this.AddChild(new Node(new Tuple<int, string>(7, "down"), sortArray(unchanged2, 4, "down")));

                }
                if (parentValue != 1)
                {
                    this.AddChild(new Node(new Tuple<int, string>(1, "up"), sortArray(unchanged3, 4, "up")));

                }
            }
            else if (value == 5)
            {
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "left"), sortArray(array, 5, "left")));

                }
                if (parentValue != 2)
                {
                    this.AddChild(new Node(new Tuple<int, string>(2, "up"), sortArray(unchanged, 5, "up")));

                }
                if (parentValue != 8)
                {
                    this.AddChild(new Node(new Tuple<int, string>(8, "down"), sortArray(unchanged2, 5, "down")));

                }
            }
            else if (value == 6)
            {
                if (parentValue != 3)
                {
                    this.AddChild(new Node(new Tuple<int, string>(3, "up"), sortArray(array, 6, "up")));

                }
                if (parentValue != 7)
                {
                    this.AddChild(new Node(new Tuple<int, string>(7, "right"), sortArray(unchanged, 6, "right")));

                }
            }
            else if (value == 7)
            {
                if (parentValue != 6)
                {
                    this.AddChild(new Node(new Tuple<int, string>(6, "left"), sortArray(array, 7, "left")));

                }
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "up"), sortArray(unchanged, 7, "up")));
                }   
                if (parentValue != 8)
                {
                    this.AddChild(new Node(new Tuple<int, string>(8, "right"), sortArray(unchanged2, 7, "right")));
                }
            }
            else if (value == 8)
            {
                if (parentValue != 5)
                {
                    this.AddChild(new Node(new Tuple<int, string>(5, "up"), sortArray(array, 8, "up")));

                }
                if (parentValue != 7)
                {
                    this.AddChild(new Node(new Tuple<int, string>(7, "left"), sortArray(unchanged2, 8, "left")));

                }
            }










            bool istrue = Enumerable.SequenceEqual(this.ArrayState, result);

            if (istrue)
            {

                Console.WriteLine("sortred");
                this.getPathway();

                return;


            }


            foreach (Node child in this.Children)
            {
                nodeQueue.Enqueue(child);

            }


            Node nextNode = nodeQueue.Peek();
            nodeQueue.Dequeue();
            FillTreeValues(nextNode, nextNode.ArrayState, nodeQueue, result);





        }

    }
}
