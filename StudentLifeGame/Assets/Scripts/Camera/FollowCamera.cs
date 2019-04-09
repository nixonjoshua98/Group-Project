using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset;

    private void Awake()
    {
        Vector3 trans = transform.position;

        trans.y += offset.y;

        transform.position = trans;
    }


    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
}