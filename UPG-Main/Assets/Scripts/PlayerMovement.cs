using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int chosenPath = 0;
    public GameObject arrowPointer;
    ArrowPointer arrowManager;
    private void Start()
    {
        arrowManager = arrowPointer.GetComponent<ArrowPointer>();
    }

    public void MovePlayer(Player player, Transform playerTransform)
    {
        ///Sets the target for the movement, just above the sphere of the node that are drawn in the gizmos
        Vector3 target = player.nextNode.position + Vector3.up * player.currentNode.radius;
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, target, player.playerSpeed);
        if (transform.position == target)
        {
            HandleDirectionInput(player);
        }
    }
    void HandleDirectionInput(Player player)
    {
        int count = player.nextNode.edge.toNodes.Count;
        ///If one of a few conditions are met, the movement is continued
        ///Return: The player confirms their choice
        ///Count < 2 means that the edge has only one toNode, so the player doesn't need to choose
        ///TODO: Add a type of node that doesn't subtract from the diceRoll, when added change this up to fit that. The new node should be used for the split paths
        if (Input.GetKeyDown(KeyCode.Return) || count < 2 )
        {
            ContinueMovement(player);return;
        }
        player.roll.text = (player.diceRoll - 1).ToString();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            chosenPath = (chosenPath + 1) % count;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            chosenPath = (chosenPath - 1 + count) % count;
        arrowManager.SpawnArrows(player.nextNode, chosenPath);
    }
    void ContinueMovement(Player player)
    {
        player.currentNode = player.nextNode;
        player.nextNode = player.currentNode.edge.toNodes[chosenPath];
        player.diceRoll--;
        player.roll.enabled = player.diceRoll > 0;
        player.roll.text = player.diceRoll.ToString();
        arrowManager.DestroyArrows();
        chosenPath = 0;
    }
}