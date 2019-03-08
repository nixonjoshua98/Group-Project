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


    private void Awake()
    {
        
    }

    // Use this for initialization
    private void Start()
    {
        Debug.Assert(ChunkPrefabs.Length != 0, "Need to assign 'ChunkPrefabs' to the LevelManager!");
        Debug.Assert(TriggerLoader != null, "Need to assign 'TriggerLoader' to the LevelManager!");

        LoadNextChunk();
    }

    // Update is called once per frame
    private void Update()
    {
        if (curTrigger.GetComponent<TriggerManager>().IsCollidingWithPlayer)
            LoadNextChunk();
    }

    private void FixedUpdate()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 7f, Camera.main.transform.position.z);
    }

    private void LoadNextChunk()
    {
        int iSelected = Random.Range(0, ChunkPrefabs.Length);
        GameObject gChunkDummy = Instantiate(new GameObject(), vCurChunkPosition, Quaternion.identity, gameObject.transform);
        gChunkDummy.name = "Chunk";

        //start at the generators position.
        Vector3 vPos = vCurChunkPosition + new Vector3(32, 0, 0);
        Vector3 vTrigger = vCurChunkPosition + new Vector3(16, 0, 0);

        Instantiate(ChunkPrefabs[iSelected], gChunkDummy.transform);
        curTrigger = Instantiate(TriggerLoader, vTrigger, Quaternion.identity, gChunkDummy.transform);

        vCurChunkPosition = vPos;
        loadedChunks.Add(gChunkDummy);

        if (loadedChunks.Count == 3)
            DeleteOldChunk();
    }

    private void DeleteOldChunk()
    {
        //clean up unused chunks.
        Destroy(loadedChunks[0]);
        loadedChunks.RemoveAt(0);
    }
}