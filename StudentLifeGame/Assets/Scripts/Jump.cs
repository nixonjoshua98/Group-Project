using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float FM;
    public float LJM;

    Rigidbody2D myRB;

    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (myRB.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (LJM - 1) * Time.deltaTime;
        }

        if (myRB.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (LJM - 1) * Time.deltaTime;
        }

        else if (myRB.velocity.y < 0)
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (FM - 1) * Time.deltaTime;
        }
    }

}
