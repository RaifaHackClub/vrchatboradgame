
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Data;

public class PlayerTurnManager : UdonSharpBehaviour
{

    private string _name;
    public VRCPlayerApi player1;
    public VRCPlayerApi player2;
    public VRCPlayerApi player3;
    public VRCPlayerApi player4;
    public VRCPlayerApi player5;
    public VRCPlayerApi player6;

    private readonly string[] player1Tiles = { "BaseSquare_001", "BaseSquare_002", "BaseSquare_003", "BaseSquare_019", "BaseSquare_021", "BaseSquare_023" };
    private readonly string[] player2Tiles = { "BaseSquare_004", "BaseSquare_005", "BaseSquare_006", "BaseSquare_022", "BaseSquare_027", "BaseSquare_026" };
    private readonly string[] player3Tiles = { "BaseSquare_007", "BaseSquare_008", "BaseSquare_009", "BaseSquare_032", "BaseSquare_031", "BaseSquare_036" };
    private readonly string[] player4Tiles = { "BaseSquare_010", "BaseSquare_011", "BaseSquare_012", "BaseSquare_033", "BaseSquare_037", "BaseSquare_035" };
    private readonly string[] player5Tiles = { "BaseSquare_013", "BaseSquare_014", "BaseSquare_015", "BaseSquare_029", "BaseSquare_034", "BaseSquare_030" };
    private readonly string[] player6Tiles = { "BaseSquare_016", "BaseSquare_017", "BaseSquare_018", "BaseSquare_020", "BaseSquare_024", "BaseSquare_025" };

    private DataDictionary playerTilesData;

    void Start()
    {
        Debug.Log("PlayerTurnManager started");
        playerTilesData = new DataDictionary();
        InitializePlayerTiles();
    }

    public void JoinAsPlayer()
    {
        _name = this.gameObject.name;
        Debug.Log("Interacted with: " + _name);
        switch (_name)
        {
            case "Player1Manager":
                player1 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + player1.displayName);
                break;

            case "Player2Manager":
                player2 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + player2.displayName);
                break;
            case "Player3Manager":
                player3 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + player3.displayName);
                break;
            case "Player4Manager":
                player4 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + player4.displayName);
                break;
            case "Player5Manager":
                player5 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + player5.displayName);
                break;
            case "Player6Manager":
                player6 = Networking.LocalPlayer;
                Debug.Log("Player joined: " + player6.displayName);
                break;
        
            default:
                Debug.Log("No player joined");
                return;
        }
    }
    private void InitializePlayerTiles()
    {
        InitializePlayerTilesFor(player1Tiles, player1Prefab, "Player1Tiles");
        InitializePlayerTilesFor(player2Tiles, player2Prefab, "Player2Tiles");
        InitializePlayerTilesFor(player3Tiles, player3Prefab, "Player3Tiles");
        InitializePlayerTilesFor(player4Tiles, player4Prefab, "Player4Tiles");
        InitializePlayerTilesFor(player5Tiles, player5Prefab, "Player5Tiles");
        InitializePlayerTilesFor(player6Tiles, player6Prefab, "Player6Tiles");
    }


 private void InitializePlayerTilesFor(string[] tileNames, GameObject prefab, string playerKey, VRCPlayerApi player)
    {
        VRC_DataList tileList = new VRC_DataList();

        foreach (string tileName in tileNames)
        {
            GameObject tile = GameObject.Find(tileName);
            if (tile != null)
            {
                GameObject newTile = VRCInstantiate(prefab);
                newTile.transform.position = tile.transform.position;
                newTile.transform.rotation = tile.transform.rotation;

                // Set the outline material based on the player
                MeshRenderer renderer = newTile.GetComponent<MeshRenderer>();
                if (player == Networking.LocalPlayer)
                {
                    renderer.material = whiteOutlineMaterial;
                }
                else
                {
                    renderer.material = redOutlineMaterial;
                }

                tileList.Add(newTile);

                // Optionally, destroy the old tile
                Destroy(tile);
            }
        }

        playerTilesData.Set(playerKey, tileList);
    }

    public void AddTileForPlayer(GameObject tile, string playerKey)
    {
        if (playerTilesData.TryGet(playerKey, out VRC_DataList tileList))
        {
            tileList.Add(tile);
            SetTilePrefabForPlayer(tile, playerKey);
        }
    }

    private void SetTilePrefabForPlayer(GameObject tile, string playerKey)
    {
        GameObject prefabToUse = null;

        switch (playerKey)
        {
            case "Player1Tiles":
                prefabToUse = player1Prefab;
                break;
            case "Player2Tiles":
                prefabToUse = player2Prefab;
                break;
            case "Player3Tiles":
                prefabToUse = player3Prefab;
                break;
            case "Player4Tiles":
                prefabToUse = player4Prefab;
                break;
            case "Player5Tiles":
                prefabToUse = player5Prefab;
                break;
            case "Player6Tiles":
                prefabToUse = player6Prefab;
                break;
        }

        if (prefabToUse != null)
        {
            GameObject newTile = VRCInstantiate(prefabToUse);
            newTile.transform.position = tile.transform.position;
            newTile.transform.rotation = tile.transform.rotation;

            // Set the outline material based on the player
            MeshRenderer renderer = newTile.GetComponent<MeshRenderer>();
            if (playerKey == GetPlayerKey(Networking.LocalPlayer))
            {
                renderer.material = whiteOutlineMaterial;
            }
            else
            {
                renderer.material = redOutlineMaterial;
            }

            Destroy(tile);
        }
    }

    private string GetPlayerKey(VRCPlayerApi player)
    {
        if (player == player1) return "Player1Tiles";
        if (player == player2) return "Player2Tiles";
        if (player == player3) return "Player3Tiles";
        if (player == player4) return "Player4Tiles";
        if (player == player5) return "Player5Tiles";
        if (player == player6) return "Player6Tiles";
        return null;
    }
}


