
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerTurnManager : UdonSharpBehaviour
{
    void Start()
    {
        Debug.Log("PlayerTurnManager started");
    }

    public void joinAsPlayer1()
    {
        // Set player 1
        Debug.Log("Player 1 joined");
    }
}
