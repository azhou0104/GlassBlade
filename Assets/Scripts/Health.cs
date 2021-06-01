using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Image HealthBar;
    public float m_CurrHealth;
    private float m_MaxHealth = 100f;

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
    }

    public void setHealth()
    {
        m_CurrHealth = 100f;
    }

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
        setHealth();
    }

    private void Update()
    {
        //where does damage get called?
        HealthBar.fillAmount = m_CurrHealth / m_MaxHealth;
    }


}
