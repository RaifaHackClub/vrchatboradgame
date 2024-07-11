
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

    private readonly string[] player1Tiles = { "BaseSquare_001", "BaseSquare_002", "BaseSquare_003", "BaseSquare_019", "BaseSquare_021", "BaseSquare_023" };
    private readonly string[] player2Tiles = { "BaseSquare_004", "BaseSquare_005", "BaseSquare_006", "BaseSquare_022", "BaseSquare_027", "BaseSquare_026" };
    private readonly string[] player3Tiles = { "BaseSquare_007", "BaseSquare_008", "BaseSquare_009", "BaseSquare_032", "BaseSquare_031", "BaseSquare_036" };
    private readonly string[] player4Tiles = { "BaseSquare_010", "BaseSquare_011", "BaseSquare_012", "BaseSquare_033", "BaseSquare_037", "BaseSquare_035" };
    private readonly string[] player5Tiles = { "BaseSquare_013", "BaseSquare_014", "BaseSquare_015", "BaseSquare_029", "BaseSquare_034", "BaseSquare_030" };
    private readonly string[] player6Tiles = { "BaseSquare_016", "BaseSquare_017", "BaseSquare_018", "BaseSquare_020", "BaseSquare_024", "BaseSquare_025" };

    public Dictionary<VRCPlayerApi, List<GameObject>> playerTiles = new Dictionary<VRCPlayerApi, List<GameObject>>();

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
            case "Player5Manager":
                _player5 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + _player5.displayName);
                break;
            case "Player6Manager":
                _player6 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + _player6.displayName);
                break;
        
            default:
                Debug.Log("No player joined");
                break;
        }
    
    if (!playerTiles.ContainsKey(player))
        {
            playerTiles[player] = new List<GameObject>();
        }
    }
    private void InitializePlayerTiles()
    {
        InitializePlayerTilesFor(player1Tiles, player1Prefab);
        InitializePlayerTilesFor(player2Tiles, player2Prefab);
        InitializePlayerTilesFor(player3Tiles, player3Prefab);
        InitializePlayerTilesFor(player4Tiles, player4Prefab);
        InitializePlayerTilesFor(player5Tiles, player5Prefab);
        InitializePlayerTilesFor(player6Tiles, player6Prefab);
    }

    private void InitializePlayerTilesFor(string[] tileNames, GameObject prefab)
    {
        foreach (string tileName in tileNames)
        {
            GameObject tile = GameObject.Find(tileName);
            if (tile != null)
            {
                GameObject newTile = VRCInstantiate(prefab);
                newTile.transform.position = tile.transform.position;
                newTile.transform.rotation = tile.transform.rotation;
                Destroy(tile);
            }
        }
    }
    public void AddTileForPlayer(GameObject tile)
    {
        VRCPlayerApi player = Networking.LocalPlayer;

        if (playerTiles.ContainsKey(player))
        {
            playerTiles[player].Add(tile);
            SetTilePrefabForPlayer(player, tile);
        }
    }





}
