
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerTurnManager : UdonSharpBehaviour
{

    private string _name;
    public VRCPlayerApi _player1;
    public VRCPlayerApi _player2;
    public VRCPlayerApi _player3;
    public VRCPlayerApi _player4;


    void Start()
    {
        Debug.Log("PlayerTurnManager started");
    }

    public void JoinAsPlayer()
    {
        _name = this.gameObject.name;
        Debug.Log("Interacted with: " + _name);
        switch (_name)
        {
            case "Player1Manager":
                _player1 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + _player1.displayName);
                break;

            case "Player2Manager":
                _player2 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + _player2.displayName);
                break;
            case "Player3Manager":
                _player3 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + _player3.displayName);
                break;
            case "Player4Manager":
                _player4 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + _player4.displayName);
                break;
            default:
                Debug.Log("No player joined");
                break;
        }
    }
}
