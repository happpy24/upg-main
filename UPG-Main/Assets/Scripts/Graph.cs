using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Graph that the entire board is on
/// </summary>
public class Graph
{ 
    public Graph()
    {
        nodes = new List<Node>();
    }
    public List <Node> nodes { get; private set; }
}
/// <summary>
/// Nodes are spaces the players can land on
/// </summary>
public class Node
{
    /*public Color nodeColor { get; set; }*/
    public Vector3 position { get; set; }
    public Edge edge { get; set; }
    public float radius { get; set; }
}
/// <summary>
/// Edges are the lines between the nodes that the players walk on
/// </summary>
public class Edge
{
    public List<Node> toNodes { get; set; }
    public Color edgeColor { get; set; }
}