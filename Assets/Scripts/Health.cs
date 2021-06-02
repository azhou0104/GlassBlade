using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image HealthBar;
    public float m_CurrHealth;
    private float m_MaxHealth = 3f;

    PlayerController Player;

    private bool m_IsDead = false;

    public bool IsDead()
    {
        return m_IsDead;
    }

    public void Damage(int t_Damage)
    {
        m_CurrHealth -= t_Damage;

        if(m_CurrHealth <= 0)
        {
            m_IsDead = true;
        }
        Debug.Log(m_CurrHealth);
    }

    private void Start()
    {
        // HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        //where does damage get called?
        HealthBar.fillAmount = Mathf.Clamp(m_CurrHealth / m_MaxHealth, 0, 1f);
    }
}
