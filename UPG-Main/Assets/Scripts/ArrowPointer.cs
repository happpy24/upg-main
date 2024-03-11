using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainCamera;
    List<GameObject> arrows = new List<GameObject>();
    public GameObject arrowObject;
    public Vector3 to { get; set; }
    public Material Selected, Deselected;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        PointArrow();
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    ///DestroyArrows is seperate because it needs to be called in PlayerMovement
    /// </summary>
    public void DestroyArrows()
    {
        foreach (GameObject arrow in arrows)
            Destroy(arrow);
    }

    /// <summary>
    /// Spawns in the arrows that point to the available spots. These arrows are colored according to the spot that is selected
    /// </summary>
    /// <param name="currentNode"></param>
    /// <param name="path"></param>
    public void SpawnArrows(Node currentNode, int path)
    {
        DestroyArrows();
        if (currentNode.edge.toNodes.Count > 1)
        {
            int index = 0;
            foreach (Node toNode in currentNode.edge.toNodes)
            {
                GameObject arrow = Instantiate(arrowObject, Vector3.zero, transform.rotation);
                ArrowPointer pointer = arrow.GetComponent<ArrowPointer>();
                pointer.to = toNode.position;
                arrowObject.GetComponent<Renderer>().material = index == path ? Selected : Deselected;
                arrows.Add(arrow);
                index++;
            }
        }
    }

    void PointArrow()
    {
        Vector3 lookAt = to - mainCamera.transform.position;
        Vector3 direction = lookAt.normalized;
        transform.SetPositionAndRotation(mainCamera.transform.position + direction * 0.25f,
            Quaternion.FromToRotation(Vector3.left, lookAt));
    }
}