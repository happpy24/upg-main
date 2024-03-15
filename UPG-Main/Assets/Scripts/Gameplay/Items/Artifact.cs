using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public string[] artifactsArr;
    private void Start()
    {
        for (int i = 0; i < artifactsArr.Length; i++)
        {
            Debug.Log("Entry: " + artifactsArr[i]);
        }

    }

    public void UpdateArray()
    {

    }

    public void checkArray()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < artifactsArr.Length; i++)
            {
                if (artifactsArr[i] == null)
                {
                    Debug.Log("Found null");
                    break;
                }
            }
        }
    }
    //connects to ItemManager script
    internal class GetPrize : ItemManager
    {
        internal GetPrize(Player player) : base(player)
        {
            path = Application.dataPath + "/Sprites/Items/artifact.png";
            itemName = "Artifact";
            desc = "This item is an artifact";
            cost = 0;
        }
        internal override void UseItem()
        {

        }

    }
}
