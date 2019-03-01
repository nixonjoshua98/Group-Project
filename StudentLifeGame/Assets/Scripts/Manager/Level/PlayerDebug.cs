using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDebug : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Debug.Assert(rb2d == null, "No RigidBody2d Located!");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.D))
            position.x += 0.1f;
        if (Input.GetKey(KeyCode.A))
            position.x -= 0.1f;
        if (Input.GetKey(KeyCode.Space))
            rb2d.AddForce(new Vector2(0, 1)*20, ForceMode2D.Force);

        transform.position = position;
    }
}
