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
    public BoxCollider2D otherTrigger;
    public float bottomMargin;
    public float leftMargin;
    public bool flipping;


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
            transform.SetParent(null);
            rigidbody.velocity = new Vector2(0f, 0f);
            attatched = null;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            bottomMargin = -bottomMargin;
            leftMargin = -leftMargin;
            if (Mathf.Abs(rotation) == 180) rotation = 0;
            else rotation = 180;
            transform.rotation = new Quaternion(0, 0, rotation, 0);
            rigidbody.gravityScale = -rigidbody.gravityScale;
            groundTrigger.enabled = true;
            flipping = false;
            otherTrigger.enabled = false;
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
            transform.SetParent(collision.transform);
            attatched = collision.gameObject;
            boxcollider.enabled = false;
            if (collision.gameObject.name == "Player1")
            {
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                if (bottomMargin < 0)
                {
                    bottomMargin = -bottomMargin;
                    leftMargin = -leftMargin;
                }
                transform.position = new Vector3(attatched.transform.position.x + leftMargin, attatched.transform.position.y + bottomMargin, attatched.transform.position.z);
            }
            else
            {
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                if (bottomMargin > 0)
                {
                    bottomMargin = -bottomMargin;
                    leftMargin = -leftMargin;
                }
                transform.position = new Vector3(attatched.transform.position.x + leftMargin, attatched.transform.position.y + bottomMargin, attatched.transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Tilemap" && groundTrigger.enabled)
        {
            groundTrigger.enabled = false;
            boxcollider.enabled = true;
            otherTrigger.enabled = true;
        }
        if (collision.name.Contains("Keyflipper") && otherTrigger.enabled)
        {
            flipping = true;
            gameObject.transform.position = collision.transform.position;
            boxcollider.enabled = false;
        }
    }
}
