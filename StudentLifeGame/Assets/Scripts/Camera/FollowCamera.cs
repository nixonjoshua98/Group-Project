using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;


    void Start()
    {
        offset = transform.position - player.transform.position;
		transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y, transform.position.z);
    }


    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
}