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
        int[] array = { 6,5,3,0,2,8,1,7,4 };
        GenerateTreeWithValues(array);
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


    static Node GenerateTreeWithValues(int[] arr)
    {
        int IndexOfZero = Array.IndexOf(arr, 0);
        int[] result = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        Queue<Node> nodeQueue = new Queue<Node>();
        Node root = new Node(new Tuple<int, string>(IndexOfZero, ""), arr);
        FillTreeValues(root, arr, nodeQueue, result);
        return root;
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






