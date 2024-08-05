using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    GameObject playerPos, aimPos;
    Vector3 direction;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player");
        aimPos = GameObject.Find("AimPoint");
        direction = aimPos.transform.position - playerPos.transform.position;

        // Di chuyển viên đạn
        

        // Quay theo hướng bắn
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction * -1);
        transform.rotation = targetRotation;

        //Hủy object sau 3s
        Invoke("DestroyGameObject", 3f);
    }

    void Update(){
       transform.position = transform.position + (direction * force * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (!collision2D.gameObject.CompareTag("Player"))
        {
            DestroyGameObject();
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
