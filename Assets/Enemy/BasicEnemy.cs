using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    float min;
    float max;
    Transform Player; // Access location of player sprite
    SpriteRenderer m_SpriteRenderer; // Allows sprite to change its color

    public float m_MaxDist = 5f; // Maximum distance the enemy is allowed to travel
    public float m_AlertDist = 8f; // Distance that enemy can notice player
    public float m_MoveSpeed = 5f; // Movement speed of enemy
    bool alerted = false; // Enemy is initially not aware of player

    Vector3 StartPosition;

    // Checks how close player is to enemy
    void FindPlayer()
    {
        if(Vector3.Distance(Player.position, transform.position) < m_AlertDist)
        {
            // If player is too close, raise alarm and change color
            alerted = true;
            m_SpriteRenderer.color = Color.red;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x - m_MaxDist;
        max = transform.position.x + m_MaxDist;
        Player = GameObject.Find("Player").transform;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(alerted)
        {
            // Enemy chases player at double speed once alerted
            if(transform.position.x - Player.position.x < 0)
            {
                transform.Translate(new Vector3(2 * m_MoveSpeed * Time.deltaTime, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(-2 * m_MoveSpeed * Time.deltaTime, 0, 0));
            }
        }
        else
        {
            // Enemy moves back and forth
            transform.position = new Vector3(Mathf.PingPong(Time.time * m_MoveSpeed, max - min) + StartPosition.x, transform.position.y, transform.position.z);
            FindPlayer();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Probably shouldn't destroy immediately, will wait for Design
            Destroy(gameObject);
            // Player should take damage here
            Debug.Log("DAMAGED PLAYER");
        }
    }
}
