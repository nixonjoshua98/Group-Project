using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    private Vector3 vCurChunkPosition = new Vector3();
    private List<GameObject> loadedChunks = new List<GameObject>();
    private GameObject curTrigger;

    [Header("Core")]
    public float Stride = 1.6f;
    [Range(0, 128)]
    public int Length = 32;
    public GameObject TriggerLoader;

    [Header("Gaps In Floor")]
    public bool AllowGaps = false;
    [Range(0, 100)]
    public int GapsFactor = 10;

    [Header("Obstacles")]   
    public bool AllowObstacles = false;
    [Range(0, 100)]
    public int ObstacleFactor = 80;

    [Header("Platform")]
    public bool AllowPlatform = false;
    [Range(0, 100)]
    public int PlatformSpawnChance = 50;
    public int yOffset = 4;
    [Range(0, 32)]
    public int xOffset = 16; 
    [Range(3, 10)]
    public int PlatformLength = 6;


    [Header("GameObjects")]
    public GameObject[] FloorPrefabs;
    public GameObject[] ObstaclePrefabs;


    private void Awake()
    {
        
    }

    // Use this for initialization
    private void Start()
    {
        Debug.Assert(FloorPrefabs.Length != 0, "Need to assign 'FloorPrefabs' to the LevelManager!");
        Debug.Assert(ObstaclePrefabs.Length != 0, "Need to assign 'ObstaclePrefabs' to the LevelManager!");
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
        
    }

    private void LoadNextChunk()
    {
        GameObject gChunkDummy = Instantiate(new GameObject(), vCurChunkPosition, Quaternion.identity, gameObject.transform);
        gChunkDummy.name = "Chunk";

        //start at the generators position.
        Vector3 vPos = gChunkDummy.transform.position;
        int iTriggerPos = Length / 2;
        bool bSpawnPlatform = (Random.Range(0, 100) > PlatformSpawnChance ? true : false);

        for (int i = 0; i != Length; i++)
        {
            //so we can detect if this block is a gap or not.
            bool bIsGap = false;

            #region Gap Instantiation
            //check if gaps are allowed.
            if (AllowGaps)
            {
                //allow instantiation only if the random number is higher than the factor.
                bool bInstantiate = (Random.Range(0, 100) > GapsFactor ? true : false);
                bIsGap = !bInstantiate;
                if (bInstantiate)
                    Instantiate(FloorPrefabs[Random.Range(0, FloorPrefabs.Length)], vPos, Quaternion.identity, gChunkDummy.transform);
            }
            #endregion

            #region Obstacle Instantion
            //check if obstacles are allowed and if this block is not a gap.
            if (AllowObstacles && !bIsGap)
            {
                //allow instantiation only if the random number is higher than the factor.
                bool bInstantiate = (Random.Range(0, 100) > ObstacleFactor ? true : false);
                if (bInstantiate)
                {
                    //Y + Stride so it sits on top of the block.
                    Vector3 vObstaclePos = vPos + new Vector3(0, Stride);
                    Instantiate(ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)], vObstaclePos, Quaternion.identity, gChunkDummy.transform);
                }
            }
            #endregion





            //instantiate trigger.
            if (iTriggerPos == i)
            {
                //delete the old trigger, create a new one.
                Destroy(curTrigger);
                curTrigger = Instantiate(TriggerLoader, vPos, Quaternion.identity, transform);
            }

            vPos.x += 1.6f;
        }

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