using UnityEngine;

internal class Artifact : ItemManager
{
    int ID = 0;
    internal Artifact(Player player) : base(player)
    {
        ID = player.ArtifactID;
        //Add ID from tiles (Nodes)
        path = Application.dataPath + "/Sprites/Items/artifact" + ID + ".png";
        //artifact0-3
        itemName = "Artifact";
        desc = "This item is an artifact";
        cost = 0;
        player.ArtifactID++;
    }
    internal override void UseItem()
    {
        player.artifacts[ID] = this;
        CheckArray();
    }

    public void CheckArray()
    {
        for (int i = 0; i < player.artifacts.Length; i++)
        {
            if (player.artifacts[i] == null)
                return;
        }
        Debug.Log(player.name + " has won!");
    }
}
