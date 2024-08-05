using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSkill : MonoBehaviour
{
    GameObject[] cdSpellObj;
    GameObject spell;
    PlayerHeal playerMP;
    cdSpell cdSpell;

    void Start()
    {
        playerMP = GameObject.FindWithTag("Player").GetComponent<PlayerHeal>();
        cdSpellObj = GameObject.FindGameObjectsWithTag("SpellCD");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cdSpell = FindNameSpell("LuminousCD").GetComponentInChildren<cdSpell>();
            spell = Resources.Load<GameObject>("Prefab/Spell/Luminous/Luminous");
            if (cdSpell.checkCD && (playerMP.currentMP - spell.GetComponent<LostMP>().MP) >= 0)
            {
                InstantiateBullet(spell);
                playerMP.UsingMP(spell.GetComponent<LostMP>().MP);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            cdSpell = FindNameSpell("BloomOfLifeCD").GetComponentInChildren<cdSpell>();
            spell = Resources.Load<GameObject>("Prefab/Spell/BloomOfLife/BloomOfLife");
            if (cdSpell.checkCD && (playerMP.currentMP - spell.GetComponent<LostMP>().MP) >= 0)
            {
                InstantiateBullet(spell);
                playerMP.UsingMP(spell.GetComponent<LostMP>().MP);
            }
        }

    }

    void InstantiateBullet(GameObject gameObject)
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }

    GameObject FindNameSpell(string name)
    {
        foreach (GameObject X in cdSpellObj)
        {
            if (X.name == name)
            {
                return X;
            }
        };
        return null;
    }
}
