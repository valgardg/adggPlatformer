using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureDoor : MonoBehaviour
{
    public bool isOpen = false;
    public float openSpeed;
    public float closeSpeed;
    public bool upsideDown = false;
    public bool active = false;
    private Vector3 startPos;
    public float maxDistance = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            OpenDoor();
        }
        else{
            
            CloseDoor();
        }
        
    }

    public void OpenDoor()
    {
        // //Debug.Log(transform.position.y);
        //Debug.Log(startPos.x);
        //Debug.Log(transform.position.x);

            if (upsideDown == false)
            {
                if (transform.position.y >= startPos.y + maxDistance || transform.position.x <= startPos.x - maxDistance)
                {
                    //Debug.Log("If 1");
                    return;
                }
                transform.Translate(Vector3.up * openSpeed * Time.deltaTime);
            }
            else
            {
                if (transform.position.y <= startPos.y - maxDistance || transform.position.x >= startPos.x + maxDistance)
                {
                    //Debug.Log("If 3");
                    return;
                }
                transform.Translate(Vector3.down * openSpeed * Time.deltaTime);
            }
    }

public void CloseDoor()
{
    if (upsideDown == false)
    {
        if (transform.position.y <= startPos.y && transform.position.x >= startPos.x)
        {
            //Debug.Log("If 2");
            return;
        }
        transform.Translate(Vector3.down * closeSpeed * Time.deltaTime);
    }
    else
    {
        if (transform.position.y >= startPos.y && transform.position.x <= startPos.x)
        {
            //Debug.Log("If 4");
            return;
        }
        transform.Translate(Vector3.up * closeSpeed * Time.deltaTime);
    }
}
}
