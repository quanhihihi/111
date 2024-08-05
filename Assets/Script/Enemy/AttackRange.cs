using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool isAttack = false;
    [HideInInspector] private bool isPlayer = false;
    public float damage;
    PlayerHeal playerHeal;

    void Start(){
        playerHeal = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHeal>();
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isAttack = true;
            isPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isAttack = false;
            isPlayer = false;
        }
    }

    public void HitPlayer()
    {
        if (isPlayer){
            playerHeal.currentHeal -= damage;
        }
    }
}
