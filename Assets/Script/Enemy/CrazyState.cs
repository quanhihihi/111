using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crazyState : MonoBehaviour
{
    // Start is called before the first frame update
    CircleCollider2D circleCollider2D;
    float crazyRange;
    float timer = 0f;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        crazyRange = circleCollider2D.radius * 3;
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            circleCollider2D.radius = crazyRange / 3;
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "AttackFromPlayer")
        {
            timer = 2f;
            circleCollider2D.radius = crazyRange;
        }
    }
}
