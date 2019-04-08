using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject[] items;

    //kind of limited but it works.
    void Awake()
    {
        int i = Random.Range(0, 100);
        GameObject chosen = (i <= 60 ? items[1] : items[0]);
        GameObject item = Instantiate(chosen, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
