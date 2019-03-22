using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [HideInInspector]
    public bool IsCollidingWithPlayer;


    void Start()
    {
        IsCollidingWithPlayer = false;
    }


    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collding with: " + collision.gameObject.name);
        if (collision.collider.CompareTag("Player"))
            IsCollidingWithPlayer = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collding with: " + collision.gameObject.name);
        if (collision.CompareTag("Player"))
            IsCollidingWithPlayer = true;
    }
}
