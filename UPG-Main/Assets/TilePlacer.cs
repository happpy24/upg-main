using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    public GameObject tile;


    // Start is called before the first frame update
    void Start()
    {
        GraphManager Manager = GameObject.FindGameObjectWithTag("Tiles").GetComponent<GraphManager>();

        ArrayList Nodes = new();
        for (int i = 0; i < Manager.board.nodes.Count; i++) 
        {
            Nodes.Add(Manager.board.nodes[i].position);
            Instantiate(tile, Manager.board.nodes[i].position, new Quaternion(0, 0, 0, 0));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
