using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject aimPos;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    float moveX, moveY;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime);
    
        //Quay theo chuot
        if (transform.position.x > aimPos.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < aimPos.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
}
