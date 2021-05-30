using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int m_MaxSwords = 3; // Max number of swords player can carry
    int cur_swords = 0; // Current number of swords on player
    Camera m_MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Destroy(other.gameObject);
            if (cur_swords < m_MaxSwords)
            {
                ++cur_swords;
                Debug.Log("Sword Picked Up");
            }
            else
            {
                Debug.Log("Unable to pick up sword, inventory full");
            }
        }
    }
}