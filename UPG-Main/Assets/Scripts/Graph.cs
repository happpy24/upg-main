using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Graph that the entire board is on
/// </summary>
internal class Graph
{ 
    internal Graph()
    {
        nodes = new List<Node>();
    }
    internal List <Node> nodes { get; private set; }
}
/// <summary>
/// Nodes are spaces the players can land on
/// </summary>
internal class Node
{
    internal Color nodeColor { get; set; }
    internal Vector3 position { get; set; }
    internal Edge edge { get; set; }
    internal float radius { get; set; }
}
/// <summary>
/// Edges are the lines between the nodes that the players walk on
/// </summary>
internal class Edge
{
    internal List<Node> toNodes { get; set; }
    internal Color edgeColor { get; set; }
}