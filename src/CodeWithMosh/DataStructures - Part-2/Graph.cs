using System;
using System.Collections.Generic;

public class Graph
{
    internal class Node
    {
        private string label;

        public Node(string label)
        {
            this.label = label;
        }

        public override string ToString()
        {
            return label;
        }
    }

    internal Dictionary<string, Node> nodes = new Dictionary<string, Node>();

    internal Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();
    public void AddNode(string label)
    {
        var node = new Node(label);
        if (!nodes.ContainsKey(label))
        {
            nodes.Add(label, node);
        }

        if (!adjacencyList.ContainsKey(node))
        {
            adjacencyList.Add(node, new List<Node>());
        }
    }

    public void AddEdge(string from, string to)
    {
        var fromNode = nodes.GetValueOrDefault(from);
        if (fromNode == null)
        {
            throw new InvalidProgramException();
        }

        var toNode = nodes.GetValueOrDefault(to);
        if (toNode == null)
        {
            throw new InvalidProgramException();
        }

        adjacencyList.GetValueOrDefault(fromNode).Add(toNode);
    }

    public void Print()
    {
        foreach (var source in adjacencyList.Keys)
        {
            var targets = adjacencyList[source];
            if (targets.Count != 0)
            {
                Console.WriteLine(source.ToString() + " is connected to " + NodePrint(targets));
            }
        }
    }

    private string NodePrint(List<Node> values)
    {
        string value = "[ ";
        foreach (var node in values)
        {
            value += node.ToString() + ", ";
        }

        value += " ]";
        return value;
    }

    public void RemoveNode(string label)
    {
        Node node = null;
        bool flag = nodes.TryGetValue(label, out node);

        if (!flag)
        {
            return;
        }

        foreach (var n in adjacencyList.Keys)
        {
            adjacencyList[n].Remove(node);
        }

        adjacencyList.Remove(node);
        nodes.Remove(label);
    }

    public void RemoveEdge(string from, string to)
    {
        var fromNode = nodes.GetValueOrDefault(from);
        if (fromNode == null)
        {
            return;
        }

        var toNode = nodes.GetValueOrDefault(to);
        if (toNode == null)
        {
            return;
        }

        adjacencyList[fromNode].Remove(toNode);
    }
}