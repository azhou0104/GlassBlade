using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_panning : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    bool automatic;

    void Start()
    {
        speed = 1; // Idk what this should be just testing lmao
        // Add code here to get player object (but we currently do not have a player object so xd)
        automatic = true; // automatic is true when camera is locked on to the player (false when player is manually controlling camera)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S key is held down");
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W key is held down");
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else
        {
            // Snap back to player
        }
    }
}
