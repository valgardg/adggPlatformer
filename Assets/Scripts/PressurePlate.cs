using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public GameObject door;
    public bool isPressed = false;
    public bool upsideDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("Player is on pressure plate");
            isPressed = true;
            door.GetComponent<PressureDoor>().active = true;
            if (upsideDown == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.125f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.125f, transform.position.z);
            }
            
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("Player is off pressure plate");
            isPressed = false;
            door.GetComponent<PressureDoor>().active = false; 
            if (upsideDown == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.125f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.125f, transform.position.z);
            }
        }
    }
}
