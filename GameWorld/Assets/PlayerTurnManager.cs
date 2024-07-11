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
    public VRCPlayerApi _player5;
    public VRCPlayerApi _player6;

    // Materials for outlines
    public Material greenTile;
    public Material redTile;

    // Default tile names for each player
    private readonly string[] player1Tiles = { "BaseSquare_004", "BaseSquare_005", "BaseSquare_006", "BaseSquare_022", "BaseSquare_027", "BaseSquare_026" };
    private readonly string[] player2Tiles = { "BaseSquare_007", "BaseSquare_008", "BaseSquare_009", "BaseSquare_032", "BaseSquare_031", "BaseSquare_036" };
    private readonly string[] player3Tiles = { "BaseSquare_010", "BaseSquare_011", "BaseSquare_012", "BaseSquare_033", "BaseSquare_037", "BaseSquare_035" };
    private readonly string[] player4Tiles = { "BaseSquare_013", "BaseSquare_014", "BaseSquare_015", "BaseSquare_029", "BaseSquare_034", "BaseSquare_030" };
    private readonly string[] player5Tiles = { "BaseSquare_016", "BaseSquare_017", "BaseSquare_018", "BaseSquare_020", "BaseSquare_024", "BaseSquare_025" };
    private readonly string[] player6Tiles = { "BaseSquare_001", "BaseSquare_002", "BaseSquare_003", "BaseSquare_019", "BaseSquare_021", "BaseSquare_023" };

    void Start()
    {
        Debug.Log("PlayerTurnManager started");
        InitializePlayerTiles();
    }

    public void JoinAsPlayer()
    {
        _name = this.gameObject.name;
        Debug.Log("Interacted with: " + _name);
        VRCPlayerApi player = Networking.LocalPlayer;

        switch (_name)
        {
            case "Player1Manager":
                _player1 = player;
                Debug.Log("Player joined: " + _player1.displayName);
                break;
            case "Player2Manager":
                _player2 = player;
                Debug.Log("Player joined: " + _player2.displayName);
                break;
            case "Player3Manager":
                _player3 = player;
                Debug.Log("Player joined: " + _player3.displayName);
                break;
            case "Player4Manager":
                _player4 = player;
                Debug.Log("Player joined: " + _player4.displayName);
                break;
            case "Player5Manager":
                _player5 = player;
                Debug.Log("Player joined: " + _player5.displayName);
                break;
            case "Player6Manager":
                _player6 = player;
                Debug.Log("Player joined: " + _player6.displayName);
                break;
            default:
                Debug.Log("No player joined");
                return;
        }

        ApplyOutlineMaterials();
    }

    private void InitializePlayerTiles()
    {
        ApplyOutlineMaterialFor(player1Tiles, "Player1Tiles");
        ApplyOutlineMaterialFor(player2Tiles, "Player2Tiles");
        ApplyOutlineMaterialFor(player3Tiles, "Player3Tiles");
        ApplyOutlineMaterialFor(player4Tiles, "Player4Tiles");
        ApplyOutlineMaterialFor(player5Tiles, "Player5Tiles");
        ApplyOutlineMaterialFor(player6Tiles, "Player6Tiles");
    }

    private void ApplyOutlineMaterials()
    {
        ApplyOutlineMaterialFor(player1Tiles, "Player1Tiles");
        ApplyOutlineMaterialFor(player2Tiles, "Player2Tiles");
        ApplyOutlineMaterialFor(player3Tiles, "Player3Tiles");
        ApplyOutlineMaterialFor(player4Tiles, "Player4Tiles");
        ApplyOutlineMaterialFor(player5Tiles, "Player5Tiles");
        ApplyOutlineMaterialFor(player6Tiles, "Player6Tiles");
    }

    private void ApplyOutlineMaterialFor(string[] tileNames, string playerKey)
    {
        foreach (string tileName in tileNames)
        {
            GameObject tile = GameObject.Find(tileName);
            if (tile != null)
            {
                ApplyOutlineMaterial(tile, playerKey);
            }
        }
    }

    private void ApplyOutlineMaterial(GameObject tile, string playerKey)
    {
        MeshRenderer renderer = tile.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            if (playerKey == GetPlayerKey(Networking.LocalPlayer))
            {
                renderer.material = greenTile;
            }
            else
            {
                renderer.material = redTile;
            }
        }
    }

    private string GetPlayerKey(VRCPlayerApi player)
    {
        if (player == _player1) return "Player1Tiles";
        if (player == _player2) return "Player2Tiles";
        if (player == _player3) return "Player3Tiles";
        if (player == _player4) return "Player4Tiles";
        if (player == _player5) return "Player5Tiles";
        if (player == _player6) return "Player6Tiles";
        return null;
    }
}
