using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PrefabBullet : MonoBehaviour
{
    public GameObject bullet;
    public float cooldownFire = 0;
    bool canFire;
    float Timer = 0;
    void Update()
    {
        Timer += Time.deltaTime;
        canFire = Timer > cooldownFire ? true : false;
        if (canFire && Input.GetMouseButtonDown(0))
        {
            Timer = 0;
            InstantiateBullet();
        }

    }

    void InstantiateBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
