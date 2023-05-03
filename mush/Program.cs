using System;
using System.Collections.Generic;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Node root = GenerateTreeWithValues(6);
        PrintTree(root, 0);
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

    static Node GenerateTreeWithValues(int depth)
    {
        Node root = new Node(new Tuple<int, string>(0, ""));
        FillTreeValues(root, depth);
        return root;
    }

    static void FillTreeValues(Node node, int depth)
    {
        if (depth == 0)
        {
            return;
        }

        int value = node.Value.Item1;
        int? parentValue = node.Parent?.Value.Item1;
        if (value == 0)
        {
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(3, "down")));
            }
            if (parentValue != 1)
            {
                node.AddChild(new Node(new Tuple<int, string>(1, "left")));
            }
        }
        else if (value == 1)
        {
            if (parentValue != 0)
            {
                node.AddChild(new Node(new Tuple<int, string>(0, "left")));
            }
            if (parentValue != 2)
            {
                node.AddChild(new Node(new Tuple<int, string>(2, "right")));
            }
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(4, "down")));
            }
        }
        else if (value == 2)
        {
            if (parentValue != 1)
            {
                node.AddChild(new Node(new Tuple<int, string>(1, "left")));
            }
            if (parentValue != 5)
            {
                node.AddChild(new Node(new Tuple<int, string>(5, "down")));
            }
        }
        else if (value == 3)
        {
            if (parentValue != 0)
            {
                node.AddChild(new Node(new Tuple<int, string>(0, "up")));
            }
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(4, "left")));
            }
        }
        else if (value == 4)
        {
            if (parentValue != 3)
            {
                node.AddChild(new Node(new Tuple<int, string>(3, "left")));
            }
            if (parentValue != 5)
            {
                node.AddChild(new Node(new Tuple<int, string>(5, "right")));
            }
            if (parentValue != 7)
            {
                node.AddChild(new Node(new Tuple<int, string>(7, "down")));
            }
            if (parentValue != 1)
            {
                node.AddChild(new Node(new Tuple<int, string>(1, "up")));
            }
        }
        else if (value == 5)
        {
            if (parentValue != 4)
            {
                node.AddChild(new Node(new Tuple<int, string>(4, "left")));
            }
            if (parentValue != 2)
            {
                node.AddChild(new Node(new Tuple<int, string>(2, "up")));
            }
            if (parentValue != 8)
            {
                node.AddChild(new Node(new Tuple<int, string>(8, "down")));
            }
        }
        else if (value == 6)
        {
            if (parentValue != 3)
            {
                node.AddChild(new Node(new Tuple<int, string>(3, "up")));
            }
            if (parentValue != 7)
            {
                node.AddChild(new Node(new Tuple<int, string>(7, "right")));
            }
        }
        else if (value == 7)
        {
            if (parentValue != 6)
            {
                node.AddChild(new Node(new Tuple<int, string>(6, "down")));
}
        if (parentValue != 4)
        {
            node.AddChild(new Node(new Tuple<int, string>(4, "up")));
        }
        if (parentValue != 8)
        {
            node.AddChild(new Node(new Tuple<int, string>(8, "right")));
        }
    }
else if (value == 8)
{
if (parentValue != 5)
{
node.AddChild(new Node(new Tuple<int, string>(5, "up")));
}
if (parentValue != 7)
{
    node.AddChild(new Node(new Tuple<int, string>(7, "left")));
}
}

        foreach (Node child in node.Children)
        {
            FillTreeValues(child, depth - 1);
        }
    }
}

class Node
{
    public Tuple<int, string> Value { get; set; }
    public List<Node> Children { get; set; }
    public Node Parent { get; set; }

    public Node(Tuple<int, string> value)
    {
        Value = value;
        Children = new List<Node>();
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
}



