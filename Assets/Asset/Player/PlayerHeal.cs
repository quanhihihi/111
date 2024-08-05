using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    HealthBar healthBar;
    MagicPoint magicPoint;
    public float maxHeal = 100f;
    public float currentHeal;
    public float maxMP = 100f;
    public float currentMP;
    void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        magicPoint = GameObject.Find("MagicPoint").GetComponent<MagicPoint>();
    }
    void Start()
    {
        currentHeal = maxHeal;
        healthBar.MaxHeal(maxHeal);
        currentMP = maxMP;
        magicPoint.MaxMP(maxMP);
    }

    void Update()
    {
        //HP
        healthBar.UpdateHeal(currentHeal);

        //MP
        if (currentMP < 100f)
        {
            currentMP += Time.deltaTime;
        }
        magicPoint.UpdateMP(currentMP);

        if ( currentHeal > 100)
        {
            currentHeal = 100;
        }
    }

    void TakeDamage(float damage)
    {
        currentHeal -= damage;
    }

    public void UsingMP(float mp)
    {
        currentMP -= mp;
    }
}