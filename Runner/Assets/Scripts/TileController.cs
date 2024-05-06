using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LileController : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activTiles = new List<GameObject>();   
    private float spawnPosition = 0;
    private float tileLenght = 100;

    [SerializeField] private Transform player;
    private int startTiles = 6;

    void Start()
    {
        for (int i = 0; i < startTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(3);
            }
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z - 70 > spawnPosition - (startTiles * tileLenght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeletTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPosition, transform.rotation);
        activTiles.Add(nextTile);
        spawnPosition += tileLenght;
    }

    private void DeletTile()
    {
        Destroy(activTiles[0]); 
        activTiles.RemoveAt(0);
    }
}
