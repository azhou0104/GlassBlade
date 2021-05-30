using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_panning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W key is held down");
        }
    }
}
