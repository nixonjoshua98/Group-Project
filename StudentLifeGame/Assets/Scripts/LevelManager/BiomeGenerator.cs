using UnityEngine;

public class BiomeGenerator : MonoBehaviour
{
    public GameObject[] floorPrefabs;
    public float Stride = 1.6f;
    public int Length = 32;

    // Use this for initialization
    void Start()
    {
        Debug.Assert(floorPrefabs.Length != 0, "Need to assign a floor prefab to the generator!");

        Vector3 pos = new Vector3();

        for (int i = 0; i != Length; i++)
        {
            Instantiate(floorPrefabs[Random.Range(0, floorPrefabs.Length)], pos, Quaternion.identity, transform);
            pos.x += 1.6f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}