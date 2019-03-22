using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    private Vector3 vCurChunkPosition = new Vector3();
    private List<GameObject> loadedChunks = new List<GameObject>();
    private GameObject curTrigger;

    [Header("Core")]
    public GameObject TriggerLoader;


    [Header("GameObjects")]
    public GameObject[] ChunkPrefabs;


    private void Start()
    {
        LoadNextChunk();
    }


    private void Update()
    {
        if (curTrigger.GetComponent<TriggerManager>().IsCollidingWithPlayer)
            LoadNextChunk();
    }


    private void LoadNextChunk()
    {
        GameObject selectedChunk = ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)];

        GameObject loadedChunk = Instantiate(selectedChunk, vCurChunkPosition, Quaternion.identity) as GameObject;

        loadedChunks.Add(loadedChunk);


        // Start at the generators position.
        Vector3 vPos = vCurChunkPosition + new Vector3(32, 0, 0);
        Vector3 vTrigger = vCurChunkPosition + new Vector3(16, 0, 0);


        curTrigger = Instantiate(TriggerLoader, vTrigger, Quaternion.identity, loadedChunk.transform);


        vCurChunkPosition = vPos;


        if (loadedChunks.Count == 3)
            DeleteOldChunk();
    }


    private void DeleteOldChunk()
    {
        // Clean up unused chunks.
        Destroy(loadedChunks[0].gameObject);
        loadedChunks.RemoveAt(0);
    }
}