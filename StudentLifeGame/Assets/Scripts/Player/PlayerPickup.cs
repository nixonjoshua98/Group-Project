using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public PlayerScore playerScore;
    public PlayerEnergy playerEnergy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreItem"))
        {
            Destroy(collision.gameObject);
            playerScore.score += 50;
        }

        else if (collision.CompareTag("EnergyItem"))
        {
            playerEnergy.currentEnergy += 10;
            Destroy(collision.gameObject);
        }
    }
}
