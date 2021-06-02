using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    public float CAMERA_SPEED = 3f; // speed of camera movement
    public float TRANSITION_SPEED = 10f; // speed of snapback
    public float MAX_DIST = 3f; // Maximum distance the camera can travel
    private GameObject Player; // Player object, used to access componenets in Player
    private PlayerController playerScript; // Used to access variables in Player

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player)
        {
            playerScript = Player.GetComponent<PlayerController>();
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

    void Update()
    {
        // Debug.Log(transform.position.x + " " + (transform.position.y - 10) + " " + transform.position.z);
        if (Input.GetAxis("Vertical") != 0 && playerScript.m_CurrState == PlayerController.PlayerState.idle)
        {
            if (Mathf.Abs(transform.position.y - Player.transform.position.y) < MAX_DIST)
            {
                // Debug.Log("S key is held down");
                // transform.Translate(new Vector3(0, CAMERA_SPEED * Time.deltaTime, 0));
                transform.position = new Vector3(Player.transform.position.x, transform.position.y + Input.GetAxis("Vertical") * CAMERA_SPEED * Time.deltaTime, transform.position.z);
            }
        }
        else
        {
            // Snap back to player
            transform.position = Vector3.Lerp(transform.position, Player.transform.position - (new Vector3(0, 0, 10)), Time.deltaTime * TRANSITION_SPEED);
        }
    }
}
