using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{

    public float FM; //Fall Multiplier
    public float LJM; // Low Jump Multiplier

    //Grabing rb obv
    Rigidbody2D myRB;

    public float JF; // Jump Force
    public float CD = 1; // Cooldown
    public float NJT = 0; // New Jump Time

    // Start is called before the first frame update
    void Start()
    {
        //slapping it awake
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Code for Movement
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


        // player 1 (ie analog stick for arcade machine)
        // 
        //-- 
        if (Time.time > NJT)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * JF;
                Debug.Log("jump");
                Debug.Log("jump now on cd");
                NJT = Time.time + CD;

            }
        }
        if (Input.GetKeyDown(KeyCode.A))
            Debug.Log("left");

        if (Input.GetKeyDown(KeyCode.D))
            Debug.Log("right");

        if (Input.GetKeyDown(KeyCode.S))
            Debug.Log("down");

        //-- 
        // player 2 (buttons for arcade machine)
        // 
        if (Time.time > NJT)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * JF;
                Debug.Log("jump");
                Debug.Log("jump now on cd");
                NJT = Time.time + CD;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Debug.Log("left");

        if (Input.GetKeyDown(KeyCode.RightArrow))
            Debug.Log("right");

        if (Input.GetKeyDown(KeyCode.DownArrow))
            Debug.Log("down");

        //-- 

        if (Input.GetKeyDown(KeyCode.Q))
            Debug.Log("exit the game");

    }
}
