using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundManager : MonoBehaviour
{

    private Vector3 vCurChunkPosition = new Vector3();
    private List<GameObject> loadedChunks = new List<GameObject>();
    private GameObject curTrigger;

    [Header("Core")]
    public GameObject TriggerLoader;
    public int MaxLoadedChunks = 4;
    public float TriggerOffset = 16;
    public float MaxBlocksPerChunk = 32;
    public float y;

    [Header("GameObjects")]
    public GameObject[] Backgrounds;

    private void Awake()
    {
        LoadNextChunk(0);
    }

    private void Update()
    {
        if (curTrigger.GetComponent<TriggerManager>().IsCollidingWithPlayer)
            LoadNextChunk(Random.Range(1, Backgrounds.Length));
    }

    private void LoadNextChunk(int forcedChunkIdx)
    {
        GameObject selectedChunk = Backgrounds[forcedChunkIdx];
        GameObject loadedChunk = Instantiate(selectedChunk, vCurChunkPosition, Quaternion.identity) as GameObject;
        loadedChunks.Add(loadedChunk);
        Vector3 vPos = vCurChunkPosition + new Vector3(0.09f * MaxBlocksPerChunk, y, 0);
        Vector3 vTrigger = vCurChunkPosition + new Vector3(0.01f * TriggerOffset, 0, 0);
        curTrigger = Instantiate(TriggerLoader, vTrigger, Quaternion.identity, loadedChunk.transform);
        vCurChunkPosition = vPos;

        if (loadedChunks.Count == MaxLoadedChunks)
            DeleteOldChunk();
    }


    private void DeleteOldChunk()
    {
        Destroy(loadedChunks[0].gameObject);
        loadedChunks.RemoveAt(0);
    }
}

