using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class DummyData : MonoBehaviour
{
    private List<string> names = new List<string> { "BlazeFury7", "FrostGlider", "EchoWanderer", "SwiftWhirl", "NovaSpire", "ShadowByte", "SkyPulse3", "EmberGaze", "AquaFlame", "SparkJolt" };
    [SerializeField]
    private GameManager gameManager;


    public void GiveNames()
    {
        for (int i = 0; i < gameManager.players.transform.childCount; i++)
        {
            Transform player = gameManager.players.transform.GetChild(i);
            int randName = Random.Range(0, names.Count);
            player.name = names[randName];
            names.RemoveAt(randName);
            Debug.Log("Player "+i+": "+player.name);
        }
    }
}
