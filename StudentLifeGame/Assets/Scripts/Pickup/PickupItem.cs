using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject[] items;

    void Awake()
    {
        int i = Random.Range(0, items.Length);

        GameObject item = Instantiate(items[i], transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
