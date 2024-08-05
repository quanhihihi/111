using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luminous : MonoBehaviour
{
    GameObject playerPos, aimPos;
    cdSpell cdSpell;
    public float CD;
    void Awake()
    {
        playerPos = GameObject.Find("Player");
        aimPos = GameObject.Find("AimPoint");
        cdSpell =  GameObject.Find("LuminousCD").GetComponentInChildren<cdSpell>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //CD
        cdSpell.setMaxCD(CD);
        //Tạo hướng
        Vector3 direction = aimPos.transform.position - playerPos.transform.position;
        transform.localPosition = transform.localPosition + direction * 1.65f;
        // Quay theo hướng bắn
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = targetRotation;
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
