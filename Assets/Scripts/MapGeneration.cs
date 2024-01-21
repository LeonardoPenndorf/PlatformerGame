using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject[] mapTiles;
    public Transform tileStorage;
    public float offSetX;
    public float minY, maxY;
    public float spawnPosition;
    public float spawnFrequency;

    // Start is called before the first frame update
    public void beginGame()
    {
        SpawnMapPiece();
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x - spawnPosition) >= spawnFrequency)
            SpawnMapPiece();
    }

    public void SpawnMapPiece()
    {
        spawnPosition = transform.position.x;

        GameObject tile = mapTiles[Random.Range(0, mapTiles.Length)];
        GameObject spawnedTile = Instantiate(tile) as GameObject;
        
        spawnedTile.transform.SetParent(tileStorage);
        spawnedTile.transform.position = new Vector3(transform.position.x + offSetX, Random.Range(minY, maxY), 0);
    }
}
