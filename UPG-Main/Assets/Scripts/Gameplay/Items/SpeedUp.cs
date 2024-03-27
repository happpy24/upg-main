using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpeedUp : ItemManager
{
    internal SpeedUp(Player player) : base(player)
    {
        path = spriteFolder + "/speedboost.png";
        itemName = "Speed Boost";
        desc = "This item gives you a +5 to your roll";
        cost = 5;
    }
    internal override void UseItem()
    {
        player.usedBoost = true;
    }

}

