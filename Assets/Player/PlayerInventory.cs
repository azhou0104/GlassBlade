using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int cur_swords = 0; // Current number of swords on player

    public float blink_time = 0.5f; // blinking time
    public float blink_stay_time = 0.8f;
    public float blink_out_time = 0.7f;
    private float _timeChecker = 0;
    private Color _color;

    Camera m_MainCamera;

    public Text swordText;
  
    
    // Start is called before the first frame update

    void Start()
    {
        m_MainCamera = Camera.main;
        swordText.color = new Color(255, 255, 255, 1);
        swordText.text = "Swords: " + 0;
        _color = swordText.color;
        //swordText.text = "Swords: " + cur_swords;

    }

    // Update is called once per frame
    void Update()
    {
        swordText.text = "Swords: " + cur_swords;
        if (cur_swords < 2)
        {
            _timeChecker += Time.deltaTime;
            if (_timeChecker < blink_time)
            {
                swordText.color = new Color(255, 0, 0, _timeChecker / blink_out_time);
            }
            else if (_timeChecker < blink_time + blink_stay_time)
            {
                swordText.color = new Color(255, 0, 0, 1);
            }
            else if (_timeChecker < blink_time + blink_stay_time + blink_out_time)
            {
                swordText.color = new Color(255, 0, 0, 1 - (_timeChecker - (blink_time + blink_stay_time)) / blink_out_time);
            }
            else
            {
                _timeChecker = 0;
            }
        }
        
        //OnTriggerEnter2D()
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Destroy(other.gameObject); // change to make swords floating down?
            ++cur_swords;
        }
    }

}