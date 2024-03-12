using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

internal class PlayerMovement : MonoBehaviour
{
    int chosenPath = 0;
    ArrowPointer arrowPointer;
    private void Start()
    {
        arrowPointer = GameObject.FindGameObjectWithTag("ArrowPointer").GetComponent<ArrowPointer>();
    }

    /// <summary>
    /// Lets the player move towards a target
    /// </summary>
    /// <param name="player"></param>
    /// <param name="playerTransform"></param>
    internal void MovePlayer(Player player, Transform playerTransform)
    {
        //Sets the target for the movement, just above the sphere of the node that are drawn in the gizmos
        Vector3 target = player.nextNode.position + Vector3.up * player.currentNode.radius;
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, target, player.playerSpeed);
        if (transform.position == target)
        {
            HandleDirectionInput(player);
        }
    }
    /// <summary>
    /// Used for handling the choice the player has to make if they come across a fork in the path
    /// </summary>
    /// <param name="player"></param>
    void HandleDirectionInput(Player player)
    {
        int count = player.nextNode.edge.toNodes.Count;
        //If one of a few conditions are met, the movement is continued
        //Return: The player confirms their choice
        //Count < 2 means that the edge has only one toNode, so the player doesn't need to choose
        if (Input.GetKeyDown(KeyCode.Return) || count < 2 )
        {
            ContinueMovement(player);return;
        }
        player.roll.text = (player.diceRoll - 1).ToString();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            chosenPath = (chosenPath + 1) % count;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            chosenPath = (chosenPath - 1 + count) % count;
        arrowPointer.SpawnArrows(player.nextNode, chosenPath);
    }
    /// <summary>
    /// Updated the player variables to continue the movement of the player
    /// </summary>
    /// <param name="player"></param>
    void ContinueMovement(Player player)
    {
        player.currentNode = player.nextNode;
        player.nextNode = player.currentNode.edge.toNodes[chosenPath];
        player.diceRoll--;
        player.roll.enabled = player.diceRoll > 0;
        player.roll.text = player.diceRoll.ToString();
        arrowPointer.DestroyArrows();
        chosenPath = 0;
    }
}