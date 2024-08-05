using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TakeDmgEffect takeDmgEffect;
    PlayerHeal playerHeal;
    float currentHeal;
    void Awake()
    {
        takeDmgEffect = GetComponent<TakeDmgEffect>();
        playerHeal = GetComponent<PlayerHeal>();
    }

    void Start()
    {
        currentHeal = playerHeal.maxHeal;
    }
    // Update is called once per frame
    void Update()
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        if (currentHeal > playerHeal.currentHeal)
        {
            takeDmgEffect.Using();
            currentHeal = playerHeal.currentHeal;
        }
    }
}
