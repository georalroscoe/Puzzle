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
        int[] array = { 8,7,6,5,4,3,2,1,0};
        if (IsSolvable(array))
        {
            GenerateTreeWithValues(array);
        }
        else
        {
            Console.WriteLine("Unsolvable");
        }
        
        Console.WriteLine("fff");
        
        

    }
    static void GenerateTreeWithValues(int[] arr)
    {
        int IndexOfZero = Array.IndexOf(arr, 0);
        int[] result = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        List<Node> nodeList = new List<Node>();
        Node root = new Node(new Tuple<int, string>(IndexOfZero, ""), arr);
        bool isSorted = false;
        List<Node> iterationLoop = new List<Node>();
        int depth = 1;
      
      root.FillTreeValues(nodeList, result, isSorted);
        while (isSorted == false)
        {
            iterationLoop.Clear();
            iterationLoop = nodeList.ToList();
            nodeList.Clear();
            isSorted = TreeValueHelper(iterationLoop,nodeList, result, isSorted);
            depth++;
            
        }

    }

    static bool IsSolvable(int[] puzzle)
    {
        int inversions = 0;
        for (int i = 0; i < puzzle.Length - 1; i++)
        {
            for (int j = i + 1; j < puzzle.Length; j++)
            {
                if (puzzle[i] > puzzle[j] && puzzle[i] != 0 && puzzle[j] != 0)
                {
                    inversions++;
                }
            }
        }
        return inversions % 2 == 0;
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






