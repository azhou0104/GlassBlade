using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //things the superclass needs:
        // Starting health
        // attack member function
        // take damage
        // die
    // Start is called before the first frame update
    public float startingHealth;
    protected bool dead;
    protected float health;
    public virtual void Start()
    {
        health = startingHealth;
    }

    public virtual void takeDamage(float damage) {
        health = health - damage;
        if (health == 0) {
            perish();
        }
    }

    public void perish() {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
