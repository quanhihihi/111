using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public float health = 50f;
    Patrol patrolGoblin;
    CapsuleCollider2D goblinCollider;
    AttackRange attackRange;
    TakeDamage takeDamage;
    bool chasePlayer = true;
    void Awake()
    {  
        takeDamage = GetComponent<TakeDamage>();
        patrolGoblin = GetComponent<Patrol>();
        goblinCollider = GetComponent<CapsuleCollider2D>();
        attackRange = GetComponentInChildren<AttackRange>();
    }

    void Start()
    {
        takeDamage.Health(health);
    }
    void Update()
    {
        health = takeDamage.health;
        if (health <= 0)
        {
            patrolGoblin.enabled = false;
            goblinCollider.enabled = false;
            Invoke("DestroyGameObject", 3f);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && health > 0)
        {
            patrolGoblin.enabled = false;
            if (chasePlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, collider.transform.position, 3f * Time.deltaTime);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            patrolGoblin.enabled = true;
        }
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void StateAttack(int a)
    {
        chasePlayer = a == 0;
    }

    public void MakeHitPlayer()
    {
        attackRange.HitPlayer();
    }
}
