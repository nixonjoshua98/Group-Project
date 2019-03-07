using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{

    public float JF;
    public float CD = 1;
    public float NJT = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
