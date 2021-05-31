using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    float min;
    float max;

    public float m_MaxDist = 5f; // Maximum distance the enemy is allowed to travel
    public float m_MoveSpeed = 5f; // Movement speed of enemy
    public bool left = true; // Enemy is walking to the left if true
    public bool alerted = false; // Enemy is initially not aware of player

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x - m_MaxDist;
        max = transform.position.x + m_MaxDist;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(alerted)
        {
            // Idk chase the player
        }
        else
        {
            // Enemy moves back and forth
            transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
        }
    }
}
