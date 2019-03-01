using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpforce = 10f;
    public float jumpCD = 2f;

    private float nextJumpTime = 0;

    private Rigidbody2D myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Get the horizontal and vertical axis
        // defult map to arrow keys 
        // The value is in the range -1 to 1
        float vert = Input.GetAxis("Vertical") * jumpforce;
        float hori = Input.GetAxis("Horizontal") * speed;

        //per second movement insetad of frame
        vert *= Time.deltaTime;
        hori *= Time.deltaTime;
        transform.Translate(hori, vert, 0);

    }
}
