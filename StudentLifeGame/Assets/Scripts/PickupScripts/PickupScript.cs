using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public int points;

    public Text pointsText;

    void Update()
    {
        pointsText.text = ("Points: " + points);
    }
}
