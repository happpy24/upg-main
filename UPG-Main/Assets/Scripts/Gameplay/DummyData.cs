using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

internal class DummyData : MonoBehaviour
{
    private List<string> names = new List<string> { "BlazeFury7", "FrostGlider", "EchoWanderer", "SwiftWhirl", "NovaSpire", "ShadowByte", "SkyPulse3", "EmberGaze", "AquaFlame", "SparkJolt" };
    [SerializeField]
    private GameManager gameManager;


    internal void GiveNames()
    {
        for (int i = 0; i < gameManager.players.Length; i++)
        {
            Transform player = gameManager.players[i].transform;
            int randName = Random.Range(0, names.Count);
            player.name = names[randName];
            names.RemoveAt(randName);
            Debug.Log("Player "+i+": "+player.name);
        }
    }
}
