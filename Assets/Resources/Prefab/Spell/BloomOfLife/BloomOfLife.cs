using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomOfLife : MonoBehaviour
{
    cdSpell cdSpell;
    PlayerHeal playerHeal;
    public float CD;
    public float HP;
    void Awake()
    {
        cdSpell =  GameObject.Find("BloomOfLifeCD").GetComponentInChildren<cdSpell>();
        playerHeal = GameObject.Find("Player").GetComponent<PlayerHeal>();
    }
    void Start()
    {
        playerHeal.currentHeal += HP;
        cdSpell.setMaxCD(CD);
        Destroy(gameObject);
    }
}
