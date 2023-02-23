using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool openingDown;
    public float openspeed;

    private bool opening;

    private void Start()
    {
        if (openingDown) openspeed = -openspeed;
    }


    private void Update()
    {
        if (opening)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + openspeed * Time.deltaTime, gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y - openspeed * Time.deltaTime, gameObject.transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        string color = gameObject.name.Split(' ')[0];
        for (int i = 1; i < collision.transform.childCount; i++)
        {
            GameObject key = collision.transform.GetChild(i).gameObject;
            if (key.name == color + " Key")
            {
                Destroy(key);
                opening = true;
            }
        }
    }
}
