using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

internal class GraphManager : MonoBehaviour
{
    internal Graph board { get; private set; }
    Edge edge;
    void Start()
    {
        board = new Graph();
        MakeNodes();
        MakeEdges();
    }
    void MakeNodes()
    {
        string s;
        List<float> split = new List<float>();
        StreamReader reader = new StreamReader(Application.dataPath + "/Textfiles/nodes.txt");
        while ((s = reader.ReadLine()) != null)
        {
            split.Clear();
            foreach(string str in s.Split(' '))
                split.Add(float.Parse(str));
            Vector3 vector = new Vector3(split[0], split[1], split[2]);
/*            Color color = new Color(split[3], split[4], split[5]);*/
            board.nodes.Add(new Node() { position = vector, /*nodeColor = color,*/ radius = 0.125f });
        }
    }
    void MakeEdges()
    {
        string s;
        List<int> splitint = new List<int>();
        List<float> splitcolor = new List<float>();
        StreamReader reader = new StreamReader(Application.dataPath + "/Textfiles/edges.txt");
        while ((s = reader.ReadLine()) != null)
        {
            splitcolor = ReturnSplit(s);
            s = reader.ReadLine();
            splitint = ReturnSplit(s).Select(f => (int)Math.Ceiling(f)).ToList();
            Color color = new Color(splitcolor[0], splitcolor[1], splitcolor[2]);
            List<Node> toNodes = new List<Node>();
            for (int i = 1; i < splitint.Count; i++)
                toNodes.Add(board.nodes[splitint[i]]);  
            edge = new Edge() {  toNodes = toNodes, edgeColor = color};
            board.nodes[splitint[0]].edge = edge;
        }
    }
    List<float> ReturnSplit(string s)
    {
        List<float> split = new List<float>();
        foreach (string str in s.Split(" "))
            split.Add(float.Parse(str)); 
        return split;
    }

    void OnDrawGizmos()
    {
        if(board == null) 
            Start();
        foreach (var node in board.nodes)
        {
/*            Gizmos.color = node.nodeColor;*/
            Gizmos.DrawSphere(node.position, node.radius);
            if (node.edge != null)
            {
                foreach (var toNode in node.edge.toNodes)
                {
/*                    Gizmos.color = node.edge.edgeColor;
*/                    Gizmos.DrawLine(node.position, toNode.position);
                }
            }
        }
    }
}
