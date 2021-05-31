using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int cur_swords = 0; // Current number of swords on player
    private float blink_time = 5f; // blinking time
    Camera m_MainCamera;

    public Text swordText;
  
    
    // Start is called before the first frame update

    void Start()
    {
        m_MainCamera = Camera.main;
        swordText.text = "Swords: " + cur_swords;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //OnTriggerEnter2D()
    }

    void FixedUpdate()
    {
        StartBlinking();
    }

    void updateSwordText()
    {
        swordText.text = "Swords: " + cur_swords;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Destroy(other.gameObject); // change to make swords floating down?
            ++cur_swords;
        }
    }

    IEnumerator Blink()
    {
        while (cur_swords < 2)
        {
            switch (swordText.color.a.ToString())
            {
                case "0":
                    swordText.color = new Color(swordText.color.r, swordText.color.g, swordText.color.b, 1);
                    yield return new WaitForSeconds(blink_time);
                    break;
                case "1":
                    swordText.color = new Color(255, 0, 0, 0);
                    yield return new WaitForSeconds(blink_time);
                    break;

            }
        }
    }

    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}