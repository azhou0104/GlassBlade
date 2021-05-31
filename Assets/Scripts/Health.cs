using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private int m_CurrHealth = 1;
    //private int m_MaxHealth = 1;

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

}
