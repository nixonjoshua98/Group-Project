using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public float speed = 10f;
    public float jumpforce = 10f;
    public float FM = 5f;
    public float LJM= -4f;

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
        if (vert > 0)
        {
            myRB.velocity = Vector2.up * jumpforce;
        }
        //float hori = Input.GetAxis("Horizontal") * speed;

        //per second movement insetad of frame
        vert *= Time.deltaTime;
        //hori *= Time.deltaTime;
        //transform.Translate(0, vert, 0);
         if (myRB.velocity.y < 0)
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (FM - 1) * Time.deltaTime;
        }
         else if (myRB.velocity.y >0 && vert < 5)
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (LJM - 1) * Time.deltaTime;
        }


    }
}
