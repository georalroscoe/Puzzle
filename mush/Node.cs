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
        public void FillTreeValues(List<Node> nodeList, int[] result)
        {


            int value = Value.Item1;
            int? parentValue = this.Parent?.Value.Item1;

            if (value == 0)
            {
                
                if (parentValue != 3)
                {
                    this.AddChild(new Node(new Tuple<int, string>(3, "down"), this.sortArray(0, "down")));



                }
                if (parentValue != 1)
                {
                    this.AddChild(new Node(new Tuple<int, string>(1, "right"), this.sortArray(0, "right")));

                }
            }
            else if (value == 1)
            {
                if (parentValue != 0)
                {
                    this.AddChild(new Node(new Tuple<int, string>(0, "left"), this.sortArray(1, "left")));

                }
                if (parentValue != 2)
                {
                    this.AddChild(new Node(new Tuple<int, string>(2, "right"), this.sortArray(1, "right")));

                }
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "down"), this.sortArray(1, "down")));

                }
            }
            else if (value == 2)
            {
                if (parentValue != 1)
                {
                    this.AddChild(new Node(new Tuple<int, string>(1, "left"), this.sortArray(2, "left")));

                }
                if (parentValue != 5)
                {
                    this.AddChild(new Node(new Tuple<int, string>(5, "down"), this.sortArray(2, "down")));

                }
            }
            else if (value == 3)
            {
                if (parentValue != 0)
                {
                    this.AddChild(new Node(new Tuple<int, string>(0, "up"), this.sortArray(3, "up")));

                }
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "right"), this.sortArray(3, "right")));

                }
                if (parentValue != 6)
                {
                    this.AddChild(new Node(new Tuple<int, string>(6, "down"), this.sortArray(3, "down")));

                }
            }
            else if (value == 4)
            {
                if (parentValue != 3)
                {
                    this.AddChild(new Node(new Tuple<int, string>(3, "left"), this.sortArray(4, "left")));

                }
                if (parentValue != 5)
                {
                    this.AddChild(new Node(new Tuple<int, string>(5, "right"), this.sortArray(4, "right")));

                }
                if (parentValue != 7)
                {
                    this.AddChild(new Node(new Tuple<int, string>(7, "down"), this.sortArray(4, "down")));

                }
                if (parentValue != 1)
                {
                    this.AddChild(new Node(new Tuple<int, string>(1, "up"), this.sortArray(4, "up")));

                }
            }
            else if (value == 5)
            {
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "left"), this.sortArray(5, "left")));

                }
                if (parentValue != 2)
                {
                    this.AddChild(new Node(new Tuple<int, string>(2, "up"), this.sortArray(5, "up")));

                }
                if (parentValue != 8)
                {
                    this.AddChild(new Node(new Tuple<int, string>(8, "down"), this.sortArray(5, "down")));

                }
            }
            else if (value == 6)
            {
                if (parentValue != 3)
                {
                    this.AddChild(new Node(new Tuple<int, string>(3, "up"), this.sortArray(6, "up")));

                }
                if (parentValue != 7)
                {
                    this.AddChild(new Node(new Tuple<int, string>(7, "right"), this.sortArray(6, "right")));

                }
            }
            else if (value == 7)
            {
                if (parentValue != 6)
                {
                    this.AddChild(new Node(new Tuple<int, string>(6, "left"), this.sortArray(7, "left")));

                }
                if (parentValue != 4)
                {
                    this.AddChild(new Node(new Tuple<int, string>(4, "up"), this.sortArray(7, "up")));
                }   
                if (parentValue != 8)
                {
                    this.AddChild(new Node(new Tuple<int, string>(8, "right"), this.sortArray(7, "right")));
                }
            }
            else if (value == 8)
            {
                if (parentValue != 5)
                {
                    this.AddChild(new Node(new Tuple<int, string>(5, "up"), this.sortArray(8, "up")));

                }
                if (parentValue != 7)
                {
                    this.AddChild(new Node(new Tuple<int, string>(7, "left"), this.sortArray(8, "left")));

                }
            }


            bool istrue = Enumerable.SequenceEqual(this.ArrayState, result);

            if (istrue)
            {

                Console.WriteLine("Solved!");
                this.getPathway();
                this.IsSorted = true;
                return;


            }


            foreach (Node child in this.Children)
            {
                nodeList.Add(child);

            }
           

        }

        public void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        public int[] sortArray(int num, String direction)
        {
            int index = -1;
            int[] tempArr = this.ArrayState.ToArray();

        switch (num)
            {
                case 0:
                    if (direction.Equals("right"))
                    {
                        index = 1;
                        swap(tempArr, 0, index);
                        return tempArr;

                    }
                    else if (direction.Equals("down"))
                    {
                        index = 3;
                        swap(tempArr, 0, index);
                        return tempArr;
                    }
                    break;
                case 1:
                    if (direction.Equals("left"))
                    {
                        index = 0;
                        swap(tempArr, 1, index);
                        return tempArr;
                    }
                    else if (direction.Equals("right"))
                    {
                        index = 2;
                        swap(tempArr, 1, index);
                        return tempArr;
                    }
                    else if (direction.Equals("down"))
                    {
                        index = 4;
                        swap(tempArr, 1, index);
                        return tempArr;
                    }
                    break;
                case 2:
                    if (direction.Equals("left"))
                    {
                        index = 1;
                        swap(tempArr, 2, index);
                        return tempArr;
                    }
                    else if (direction.Equals("down"))
                    {
                        index = 5;
                        swap(tempArr, 2, index);
                        return tempArr;
                    }
                    break;
                case 3:
                    if (direction.Equals("right"))
                    {
                        index = 4;
                        swap(tempArr, 3, index);
                        return tempArr;
                    }
                    else if (direction.Equals("up"))
                    {
                        index = 0;
                        swap(tempArr, 3, index);
                        return tempArr;
                    }
                    else if (direction.Equals("down"))
                    {
                        index = 6;
                        swap(tempArr, 3, index);
                        return tempArr;
                    }
                    break;
                case 4:
                    if (direction.Equals("right"))
                    {
                        index = 5;
                        swap(tempArr, 4, index);
                        return tempArr;
                    }
                    else if (direction.Equals("up"))
                    {
                        index = 1;
                        swap(tempArr, 4, index);
                        return tempArr;
                    }
                    else if (direction.Equals("left"))
                    {
                        index = 3;
                        swap(tempArr, 4, index);
                        return tempArr;
                    }
                    else if (direction.Equals("down"))
                    {
                        index = 7;
                        swap(tempArr, 4, index);
                        return tempArr;
                    }
                    break;
                case 5:
                    if (direction.Equals("up"))
                    {
                        index = 2;
                        swap(tempArr, 5, index);
                        return tempArr;
                    }
                    else if (direction.Equals("left"))
                    {
                        index = 4;
                        swap(tempArr, 5, index);
                        return tempArr;
                    }
                    else if (direction.Equals("down"))
                    {
                        index = 8;
                        swap(tempArr, 5, index);
                        return tempArr;
                    }
                    break;
                case 6:
                    if (direction.Equals("up"))
                    {
                        index = 3;
                        swap(tempArr, 6, index);
                        return tempArr;
                    }
                    else if (direction.Equals("right"))
                    {
                        index = 7;
                        swap(tempArr, 6, index);
                        return tempArr;
                    }
                    break;
                case 7:
                    if (direction.Equals("up"))
                    {
                        index = 4;
                        swap(tempArr, 7, index);
                        return tempArr;
                    }
                    else if (direction.Equals("left"))
                    {
                        index = 6;
                        swap(tempArr, 7, index);
                        return tempArr;
                    }
                    else if (direction.Equals("right"))
                    {
                        index = 8;
                        swap(tempArr, 7, index);
                        return tempArr;
                    }
                    break;
                case 8:
                    if (direction.Equals("up"))
                    {
                        index = 5;
                        swap(tempArr, 8, index);
                        return tempArr;
                    }
                    else if (direction.Equals("left"))
                    {
                        index = 7;
                        swap(tempArr, 8, index);
                        return tempArr;
                    }
                    break;
                default:
                    return tempArr;




            }
            return tempArr;
        }
    }

}
