using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Spawner : UdonSharpBehaviour
{
    public GameObject swordsmanPrefab;
    public GameObject archerPrefab;
    public GameObject magePrefab;
    public GameObject canvas;

    public void SpawnSwordsman()
    {
        SpawnTroop(swordsmanPrefab);
    }

    public void SpawnArcher()
    {
        SpawnTroop(archerPrefab);
    }

    public void SpawnMage()
    {
        SpawnTroop(magePrefab);
    }

    private void SpawnTroop(GameObject prefab)
    {
        // Calculate the spawn position 2 units below the Canvas
        Vector3 spawnPosition = canvas.transform.position - new Vector3(0, 0, 0);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
