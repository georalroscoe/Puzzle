using System;
using System.Collections;

using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using NodeClass;
using System.Runtime.CompilerServices;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1,8,2,5,7,0,4,3,6 };
        GenerateTreeWithValues(array);
        Console.WriteLine("fff");
        /*PrintTree(root, 0);*/

    }
    static void GenerateTreeWithValues(int[] arr)
    {
        int IndexOfZero = Array.IndexOf(arr, 0);
        int[] result = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        List<Node> nodeList = new List<Node>();
        Node root = new Node(new Tuple<int, string>(IndexOfZero, ""), arr);
        //nodeList.Add(root);
        bool isSorted = false;
        List<Node> iterationLoop = new List<Node>();

      
      root.FillTreeValues(nodeList, result, isSorted);
        while (isSorted == false)
        {
            iterationLoop.Clear();
            iterationLoop = nodeList.ToList();
            nodeList.Clear();
            isSorted = TreeValueHelper(iterationLoop,nodeList, result, isSorted);
            
        }
        

          
     
       
    }
    static bool TreeValueHelper(List<Node> iterationLoop, List<Node> originallist, int[] result, bool isSorted)
    {
        foreach(Node node in iterationLoop)
        {
            
            
                node.FillTreeValues(originallist, result, isSorted);
            if (node.IsSorted)
            {
                return true;
            }

        }
        return false;
    }

    
    

}






