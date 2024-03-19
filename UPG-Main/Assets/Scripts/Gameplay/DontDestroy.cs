using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string objectID;

    private void Awake()
    {
        objectID = name + transform.position.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroy[] dontDestroys = FindObjectsOfType<DontDestroy>();
        for (int i = 0; i < dontDestroys.Length; i++)
        {
            if (dontDestroys[i] != this)
            {
                if (dontDestroys[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
