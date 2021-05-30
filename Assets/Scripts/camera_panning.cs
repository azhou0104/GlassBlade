using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_panning : MonoBehaviour
{
    public float speed = 3f; // Speed of camera movement
    public float transitionSpeed = 10f; // Speed of snapback
    public float maxDist = 3f; // Maximum distance the camera can travel
    private GameObject Player; // Player object

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player)
        {
            transform.position = Player.transform.position;
            transform.position -= new Vector3(0, 0, 10); // Camera should be above player
            // Debug.Log(transform.position.x + " " + (transform.position.y - 10) + " " + transform.position.z);
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
        // Don't use this lmao
    }

    void FixedUpdate()
    {
        // Debug.Log(transform.position.x + " " + (transform.position.y - 10) + " " + transform.position.z);
        if (Input.GetKey(KeyCode.S))
        {
            if (Mathf.Abs(transform.position.y - Player.transform.position.y) < maxDist)
            {
                // Debug.Log("S key is held down");
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
            else
            {
                // Debug.Log("Camera has gone too far");
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (Mathf.Abs(transform.position.y - Player.transform.position.y) < maxDist)
            {
                // Debug.Log("W key is held down");
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            else
            {
                // Debug.Log("Camera has gone too far");
            }
        }
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    // Debug.Log("D key is held down");
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //}
        else
        {
            // Snap back to player
            transform.position = Vector3.Lerp(transform.position, Player.transform.position - (new Vector3(0, 0, 10)), Time.deltaTime * transitionSpeed);
        }
    }
}
