using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public bool IsCollidingWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        IsCollidingWithPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collding with: " + collision.gameObject.name);
        if (collision.gameObject.name == "PlayerTest")
            IsCollidingWithPlayer = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collding with: " + collision.gameObject.name);
        if (collision.gameObject.name == "PlayerTest")
            IsCollidingWithPlayer = true;
    }
}
