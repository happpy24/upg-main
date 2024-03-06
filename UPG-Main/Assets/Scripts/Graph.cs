using System.Collections.Generic;
using UnityEngine;

public class Graph
{ 
    public Graph()
    {
        nodes = new List<Node>();
    }
    public List <Node> nodes { get; private set; }
}

public class Node
{
    public Color nodeColor { get; set; }
    public Vector3 position { get; set; }
    public Edge edge { get; set; }
    public float radius { get; set; }
}

public class Edge
{
    public List<Node> toNodes { get; set; }
    public Color edgeColor { get; set; }
}