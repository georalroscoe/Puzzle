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
        public int Depth { get; set; }

        public Node(Tuple<int, string> value, int[] arrayState, int depth)
        {
            Value = value;
            Children = new List<Node>();
            ArrayState = arrayState;
           Depth = depth;
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
    }
}
