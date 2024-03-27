using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class DoubleDice : ItemManager
{
    internal DoubleDice(Player player) : base(player)
    {
        path = spriteFolder + "/doubledice.png";
        itemName = "Double Dice";
        desc = "This item gives you a second dice to roll";
        cost = 8;
    }
    internal override void UseItem()
    {
        player.usedDouble = true;
    }

}
