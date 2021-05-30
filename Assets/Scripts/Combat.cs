using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform m_AttackPoint;
    public int m_Damage = 1;
    public float m_AttackRange = 0.5f;
    public LayerMask m_EnemyLayers;

    public void Update()
    {
        if(Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    public void Attack()
    {
        //set animation for attack
        Debug.Log("Attack!");

        if(m_AttackPoint != null)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(m_AttackPoint.position, m_AttackRange, m_EnemyLayers);

            for (int i = 0; i < hitEnemies.Length; i++)
            {
                hitEnemies[i].GetComponent<Health>().Damage(m_Damage);
            }
        }
        
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(m_AttackPoint.position, m_AttackRange);
    }
}
