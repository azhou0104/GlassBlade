using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private int m_CurrHealth;
    private int m_MaxHealth;

    private bool m_IsDead;

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

}
