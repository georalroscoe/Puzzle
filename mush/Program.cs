using System;
using System.Collections;

using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using NodeClass;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 3,1,2,0,4,5,6,7,8 };
        GenerateTreeWithValues(array);
        Console.WriteLine("fff");
        /*PrintTree(root, 0);*/

    }
    static Node GenerateTreeWithValues(int[] arr)
    {
        int IndexOfZero = Array.IndexOf(arr, 0);
        int[] result = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        Queue<Node> nodeQueue = new Queue<Node>();
        Node root = new Node(new Tuple<int, string>(IndexOfZero, ""), arr);
        root.FillTreeValues(nodeQueue, result);
        return root;
    }

    
    

}






