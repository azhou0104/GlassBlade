using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_panning : MonoBehaviour
{
    float speed; // Speed of camera movement
    bool automatic; // automatic is true when camera is locked on to the player (false when player is manually controlling camera) (we probably don't actually need this)
    GameObject Player; // Player object

    // Start is called before the first frame update
    void Start()
    {
        speed = 1; // Idk what this should be just testing lmao
        // Add code here to get player object (but we currently do not have a player object so xd)
        // automatic = true;
        Player = GameObject.Find("Player");
        if (Player)
        {
            //transform.position = Player.transform.position;
            //transform.position += new Vector3(0, 0, 10); // Camera should be above player
            Debug.Log(transform.position.x + " " + (transform.position.y + 10) + " " + transform.position.z);
        }
        else
        {
            Debug.Log("No Player Object");
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position.x + " " + (transform.position.y + 10) + " " + transform.position.z);
        if (Input.GetKey(KeyCode.S))
        {
            // Debug.Log("S key is held down");
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            // Debug.Log("W key is held down");
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    // Debug.Log("D key is held down");
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //}
        else
        {
            // Snap back to player
            // TODO: Make this move smoothly, not instantaneously
            transform.position = Player.transform.position;
            transform.position += new Vector3(0, 0, 10); // Camera should be above player
        }
    }
}
