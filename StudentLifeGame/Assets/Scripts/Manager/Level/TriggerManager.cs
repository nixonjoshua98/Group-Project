using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [HideInInspector]
    public bool IsCollidingWithPlayer;

    void Start()
    {
        IsCollidingWithPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            IsCollidingWithPlayer = true;
    }
}
