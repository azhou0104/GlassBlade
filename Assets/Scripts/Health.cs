using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image HealthBar;
    private float m_CurrHealth;
    private float m_MaxHealth = 2f;

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
        HealthBar.fillAmount = Mathf.Clamp(m_CurrHealth / m_MaxHealth, 0, 1f);
        Debug.Log("HEALTH: " + HealthBar.fillAmount);
    }

    private void Start()
    {
        // HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
        m_CurrHealth = m_MaxHealth;
    }

    private void Update()
    {
        
    }
}
