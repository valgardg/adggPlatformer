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
            if (upsideDown == false)
            {
                if (transform.position.y >= startPos.y + maxDistance)
                {
                    return;
                }
                transform.Translate(Vector3.up * openSpeed * Time.deltaTime);
            }
            else
            {
                if (transform.position.y <= startPos.y - maxDistance)
                {
                    return;
                }
                transform.Translate(Vector3.down * openSpeed * Time.deltaTime);
            }
    }

    public void CloseDoor()
    {
        Debug.Log("CloseDoor");
        Debug.Log(upsideDown);

        if (upsideDown == false)
        {
            if (transform.position.y <= startPos.y)
            {
                return;
            }
            transform.Translate(Vector3.down * closeSpeed * Time.deltaTime);
        }
        else
        {
            if (transform.position.y >= startPos.y)
            {
                return;
            }
            transform.Translate(Vector3.up * closeSpeed * Time.deltaTime);
        }
    }
}
