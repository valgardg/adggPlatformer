using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private GameObject attatched;
    private int rotation;

    public Rigidbody2D rigidbody;
    public BoxCollider2D boxcollider;
    public BoxCollider2D groundTrigger;
    public float bottomMargin;
    public float leftMargin;
    public bool flipping;
    public float dropoff;


    // Start is called before the first frame update
    void Start()
    {
        rotation = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flipping)
        {
            rigidbody.velocity = new Vector2(0f, 0f);
            attatched = null;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+dropoff, gameObject.transform.position.z);
            dropoff = -dropoff;
            bottomMargin = -bottomMargin;
            leftMargin = -leftMargin;
            if (rotation != 0) rotation = 0;
            else rotation += 180;
            transform.rotation = new Quaternion(0, 0, rotation, 0);
            rigidbody.gravityScale = -rigidbody.gravityScale;
            groundTrigger.enabled = true;
            flipping = false;
        }
        if (attatched != null)
        {
            transform.position = new Vector3(attatched.transform.position.x + leftMargin, attatched.transform.position.y + bottomMargin, attatched.transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            attatched = collision.gameObject;
            boxcollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Tilemap")
        {
            groundTrigger.enabled = false;
            boxcollider.enabled = true;
        }
    }
}
