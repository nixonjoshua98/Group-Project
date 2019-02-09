using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.D))
            position.x += 0.1f;
        if (Input.GetKey(KeyCode.A))
            position.x -= 0.1f;
        if (Input.GetKey(KeyCode.Space))
            position.y += 0.5f;

        transform.position = position;
    }
}
