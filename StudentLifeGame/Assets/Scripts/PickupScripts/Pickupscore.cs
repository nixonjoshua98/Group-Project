using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickupscore : MonoBehaviour
{

    private PickupScript ps;
    ////private PlayerEnergy pe;



    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<PickupScript>();
        //pe = GameObject.FindGameObjectWithTag("Energy").GetComponent<PlayerEnergy>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pickup"))
        {
            Destroy(col.gameObject);
            ps.points += 1;
            //pe.currentEnergy += 50;


        }
    }
}
