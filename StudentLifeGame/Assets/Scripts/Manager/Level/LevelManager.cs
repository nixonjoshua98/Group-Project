﻿using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    private Vector3 vCurChunkPosition = new Vector3();

    [Header("Core")]
    public float Stride = 1.6f;
    [Range(0, 128)]
    public int Length = 32;
    public GameObject TriggerLoader;

    [Header("Gaps")]
    public bool AllowGaps = false;
    [Range(0, 100)]
    public int GapsFactor = 10;

    [Header("Obstacles")]   
    public bool AllowObstacles = false;
    [Range(0, 100)]
    public int ObstacleFactor = 80;

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

    }

    private void FixedUpdate()
    {
        
    }

    private void LoadNextChunk()
    {
        GameObject gChunkDummy = Instantiate(new GameObject(), vCurChunkPosition, Quaternion.identity, gameObject.transform);
        gChunkDummy.name = "Chuck";

        //start at the generators position.
        Vector3 vPos = gChunkDummy.transform.position;
        int iTriggerPos = Length / 2;

        for (int i = 0; i != Length; i++)
        {
            //so we can detect if this block is a gap or not.
            bool bIsGap = false;

            //check if gaps are allowed.
            if (AllowGaps)
            {
                //allow instantiation only if the random number is higher than the factor.
                bool bInstantiate = (Random.Range(0, 100) > GapsFactor ? true : false);
                bIsGap = !bInstantiate;
                if (bInstantiate)
                    Instantiate(FloorPrefabs[Random.Range(0, FloorPrefabs.Length)], vPos, Quaternion.identity, gChunkDummy.transform);
            }

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

            //instantiate trigger.
            if(iTriggerPos == i)
                Instantiate(TriggerLoader, vPos, Quaternion.identity, transform);

            vPos.x += 1.6f;
        }

        vCurChunkPosition = vPos;
    }
}