using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    public GameObject tile;
    public Transform parent;


    // Start is called before the first frame update
    void Start()
    {
        PlaceTiles();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Instantiates a Tile cube from the prefabs on top of a node.
    /// </summary>
    void PlaceTiles()
    {
        GraphManager Manager = GameObject.FindGameObjectWithTag("Tiles").GetComponent<GraphManager>();

        for (int i = 0; i < Manager.board.nodes.Count; i++)
        {
            GameObject tileInstance = Instantiate(tile, Manager.board.nodes[i].position, new Quaternion(0, 0, 0, 0));
            tileInstance.transform.SetParent(parent, false);
        }
    }
}
