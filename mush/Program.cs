using System;
using System.Collections;

using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using NodeClass;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1,0,2,3,5,8,4,6,1 };
        GenerateTreeWithValues(12, array);
        Console.WriteLine("fff");
        /*PrintTree(root, 0);*/

    }

    static void PrintTree(Node node, int depth)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine($"{new string(' ', depth * 2)}{node.Value.Item1}, {node.Value.Item2}");

        foreach (Node child in node.Children)
        {

            PrintTree(child, depth + 1);
        }
    }
    public static int[] sortArray(int[] arr, int num, String direction)
    {
        int index = -1;

        switch (num)
        {
            case 0:
                if (direction.Equals("right"))
                {
                    index = 1;
                    swap(arr, 0, index);
                    return arr;

                }
                else if (direction.Equals("down"))
                {
                    index = 3;
                    swap(arr, 0, index);
                    return arr;
                }
                break;
            case 1:
                if (direction.Equals("left"))
                {
                    index = 0;
                    swap(arr, 1, index);
                    return arr;
                }
                else if (direction.Equals("right"))
                {
                    index = 2;
                    swap(arr, 1, index);
                    return arr;
                }
                else if (direction.Equals("down"))
                {
                    index = 4;
                    swap(arr, 1, index);
                    return arr;
                }
                break;
            case 2:
                if (direction.Equals("left"))
                {
                    index = 1;
                    swap(arr, 2, index);
                    return arr;
                }
                else if (direction.Equals("down"))
                {
                    index = 5;
                    swap(arr, 2, index);
                    return arr;
                }
                break;
            case 3:
                if (direction.Equals("right"))
                {
                    index = 4;
                    swap(arr, 3, index);
                    return arr;
                }
                else if (direction.Equals("up"))
                {
                    index = 0;
                    swap(arr, 3, index);
                    return arr;
                }
                else if (direction.Equals("down"))
                {
                    index = 6;
                    swap(arr, 3, index);
                    return arr;
                }
                break;
            case 4:
                if (direction.Equals("right"))
                {
                    index = 5;
                    swap(arr, 4, index);
                    return arr;
                }
                else if (direction.Equals("up"))
                {
                    index = 1;
                    swap(arr, 4, index);
                    return arr;
                }
                else if (direction.Equals("left"))
                {
                    index = 3;
                    swap(arr, 4, index);
                    return arr;
                }
                else if (direction.Equals("down"))
                {
                    index = 7;
                    swap(arr, 4, index);
                    return arr;
                }
                break;
            case 5:
                if (direction.Equals("up"))
                {
                    index = 2;
                    swap(arr, 5, index);
                    return arr;
                }
                else if (direction.Equals("left"))
                {
                    index = 4;
                    swap(arr, 5, index);
                    return arr;
                }
                else if (direction.Equals("down"))
                {
                    index = 8;
                    swap(arr, 5, index);
                    return arr;
                }
                break;
            case 6:
                if (direction.Equals("up"))
                {
                    index = 3;
                    swap(arr, 6, index);
                    return arr;
                }
                else if (direction.Equals("right"))
                {
                    index = 7;
                    swap(arr, 6, index);
                    return arr;
                }
                break;
            case 7:
                if (direction.Equals("up"))
                {
                    index = 4;
                    swap(arr, 7, index);
                    return arr;
                }
                else if (direction.Equals("left"))
                {
                    index = 6;
                    swap(arr, 7, index);
                    return arr;
                }
                else if (direction.Equals("right"))
                {
                    index = 8;
                    swap(arr, 7, index);
                    return arr;
                }
                break;
            case 8:
                if (direction.Equals("up"))
                {
                    index = 5;
                    swap(arr, 8, index);
                    return arr;
                }
                else if (direction.Equals("left"))
                {
                    index = 7;
                    swap(arr, 8, index);
                    return arr;
                }
                break;
            default:
                return arr;




        }
        return arr;
    }

    public static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }


    static Node GenerateTreeWithValues(int depth, int[] arr)
    {
        int IndexOfZero = Array.IndexOf(arr, 0);
        Queue<Node> nodeQueue = new Queue<Node>();
        Node root = new Node(new Tuple<int, string>(IndexOfZero, ""), arr, depth);
        FillTreeValues(root, depth, arr, nodeQueue);
        return root;
    }

    static void FillTreeValues(Node node, int depth, int[] array, Queue<Node> nodeQueue)
    {


        if (depth == 0)
        {

            return;
        }



        int[] result = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };


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



        int value = node.Value.Item1;
        int? parentValue = node.Parent?.Value.Item1;

        if (value == 0)
        {

            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(3, "down"), sortArray(array, 0, "down"), depth));



            }
            if (parentValue != 1)
            {
                node.AddChild(new Node(new Tuple<int, string>(1, "right"), sortArray(unchanged, 0, "right"), depth));

            }
        }
        else if (value == 1)
        {
            if (parentValue != 0)
            {
                node.AddChild(new Node(new Tuple<int, string>(0, "left"), sortArray(array, 1, "left"), depth));

            }
            if (parentValue != 2)
            {
                node.AddChild(new Node(new Tuple<int, string>(2, "right"), sortArray(unchanged, 1, "right"), depth));

            }
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(4, "down"), sortArray(unchanged2, 1, "down"), depth));

            }
        }
        else if (value == 2)
        {
            if (parentValue != 1)
            {
                node.AddChild(new Node(new Tuple<int, string>(1, "left"), sortArray(array, 2, "left"), depth));

            }
            if (parentValue != 5)
            {
                node.AddChild(new Node(new Tuple<int, string>(5, "down"), sortArray(unchanged, 2, "down"), depth));

            }
        }
        else if (value == 3)
        {
            if (parentValue != 0)
            {
                node.AddChild(new Node(new Tuple<int, string>(0, "up"), sortArray(array, 3, "up"), depth));

            }
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(4, "right"), sortArray(unchanged, 3, "right"), depth));

            }
            if (parentValue != 6)
            {
                node.AddChild(new Node(new Tuple<int, string>(6, "down"), sortArray(unchanged2, 3, "down"), depth));

            }
        }
        else if (value == 4)
        {
            if (parentValue != 3)
            {
                node.AddChild(new Node(new Tuple<int, string>(3, "left"), sortArray(array, 4, "left"), depth));

            }
            if (parentValue != 5)
            {
                node.AddChild(new Node(new Tuple<int, string>(5, "right"), sortArray(unchanged, 4, "right"), depth));

            }
            if (parentValue != 7)
            {
                node.AddChild(new Node(new Tuple<int, string>(7, "down"), sortArray(unchanged2, 4, "down"), depth));

            }
            if (parentValue != 1)
            {
                node.AddChild(new Node(new Tuple<int, string>(1, "up"), sortArray(unchanged3, 4, "up"), depth));

            }
        }
        else if (value == 5)
        {
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(4, "left"), sortArray(array, 5, "left"), depth));

            }
            if (parentValue != 2)
            {
                node.AddChild(new Node(new Tuple<int, string>(2, "up"), sortArray(unchanged, 5, "up"), depth));

            }
            if (parentValue != 8)
            {
                node.AddChild(new Node(new Tuple<int, string>(8, "down"), sortArray(unchanged2, 5, "down"), depth));

            }
        }
        else if (value == 6)
        {
            if (parentValue != 3)
            {
                node.AddChild(new Node(new Tuple<int, string>(3, "up"), sortArray(array, 6, "up"), depth));

            }
            if (parentValue != 7)
            {
                node.AddChild(new Node(new Tuple<int, string>(7, "right"), sortArray(unchanged, 6, "right"), depth));

            }
        }
        else if (value == 7)
        {
            if (parentValue != 6)
            {
                node.AddChild(new Node(new Tuple<int, string>(6, "left"), sortArray(array, 7, "left"), depth));

            }
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(4, "up"), sortArray(unchanged, 7, "up"), depth));
            }
            if (parentValue != 8)
            {
                node.AddChild(new Node(new Tuple<int, string>(8, "right"), sortArray(unchanged2, 7, "right"), depth));
            }
        }
        else if (value == 8)
        {
            if (parentValue != 5)
            {
                node.AddChild(new Node(new Tuple<int, string>(5, "up"), sortArray(array, 8, "up"), depth));

            }
            if (parentValue != 7)
            {
                node.AddChild(new Node(new Tuple<int, string>(7, "left"), sortArray(unchanged2, 8, "left"), depth));

            }
        }

       




       



        bool istrue = Enumerable.SequenceEqual(node.ArrayState, result);

        if (istrue)
        {

            Console.WriteLine("sortred");
            node.getPathway();
           
            return;


        }

         
            foreach (Node child in node.Children)
            {
                nodeQueue.Enqueue(child);

            }


            Node nextNode = nodeQueue.Peek();
        nodeQueue.Dequeue();
        FillTreeValues(nextNode, nextNode.Depth - 1, nextNode.ArrayState, nodeQueue);
            
        



    }

    public static List<Node> GetAllNodes(Node root)
    {
        List<Node> nodes = new List<Node>();
        Stack<Node> stack = new Stack<Node>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            Node current = stack.Pop();
            nodes.Add(current);

            foreach (Node child in current.Children)
            {
                stack.Push(child);
            }
        }

        return nodes;
    }

}






