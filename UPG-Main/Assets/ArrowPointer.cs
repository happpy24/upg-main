using System;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    // Start is called before the first frame update
    public Mesh mesh;
    GameObject mainCamera;
    Color color;
    public Vector3 to {get; set;}
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        PointArrow();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void PointArrow()
    {
        Vector3 lookAt = to - mainCamera.transform.position;
        Vector3 direction = lookAt.normalized;
        transform.SetPositionAndRotation(mainCamera.transform.position + direction * 0.25f, 
            Quaternion.FromToRotation(Vector3.left, lookAt));
    }
}
