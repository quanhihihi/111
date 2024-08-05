using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGoblin : MonoBehaviour
{
    EnemyController enemyController;
    Animator animator;
    CheckMove checkMove;
    AttackRange attackRange;
    TakeDmgEffect takeDmgEffect;
    private float currentHeal;
    void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
        checkMove = GetComponent<CheckMove>();
        takeDmgEffect = GetComponent<TakeDmgEffect>();
        attackRange = GetComponentInChildren<AttackRange>();
    }
    void Start()
    {
        currentHeal = enemyController.health;
    }

    // Update is called once per frame
    void Update()
    {
        //Animation Deal
        if (enemyController.health <= 0f)
        {
            animator.Play("Deal");
        }

        //Animation Move
        animator.SetBool("Move", checkMove.isMove);

        //Hiệu ứng nhận Damage
        if (currentHeal > enemyController.health && currentHeal > 0f)
        {
            takeDmgEffect.Using();
            currentHeal = enemyController.health;
        }

        //Animation tấn công
        if (attackRange.isAttack && currentHeal > 0f)
        {
            animator.Play("Hit");
        }
    }

    public void AttackAnimationEnd()
    {
        // Chuyển về animation mặc định
        animator.Play("Idle");
    }
}
