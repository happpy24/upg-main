using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DoubleDice : ItemManager
{
    internal DoubleDice(Player player) : base(player)
    {
        path = Application.dataPath + "/Sprites/Items/doubledice.png";
    }
    internal override void UseItem()
    {
        player.usedDouble = true;
    }

}
