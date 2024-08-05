using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [HideInInspector] public float health;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "AttackFromPlayer")
        {
            Damage dmg = collision2D.gameObject.GetComponent<Damage>();
            if (dmg != null)
            {
                health -= dmg.damage;
            }
        }
    }


    public void Health(float health)
    {
        this.health = health;
    }
}
