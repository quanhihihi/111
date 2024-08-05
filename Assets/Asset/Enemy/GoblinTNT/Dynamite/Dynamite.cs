using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    Animator animator;
    GameObject player;
    EnemyController enemyController;
    CircleCollider2D circleCollider2D;
    public float throwHeight = 5f; // Độ cao
    public float throwDuration = 1f; // Thời gian

    private Vector3 throwStartPosition;
    private Vector3 throwEndPosition;
    private Vector3 throwMidPosition; // Điểm trung đỉnh của đường Bezier

    private float throwTimer = 0f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.Find("GoblinTNT") != null)
            enemyController = GameObject.Find("GoblinTNT").GetComponent<EnemyController>();
    }
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        throwStartPosition = transform.position;
        throwEndPosition = player.transform.position;
        throwMidPosition = (throwStartPosition + throwEndPosition) / 2f;
        throwMidPosition += Vector3.up * throwHeight; // Tăng độ cao cho điểm trung gian
    }

    void Update()
    {
        throwTimer += Time.deltaTime;

        if (throwTimer <= throwDuration)
        {
            transform.Rotate(0f, 0f, 360f * Time.deltaTime);
            float t = throwTimer / throwDuration;
            Vector3 throwPosition = CalculateBezierPoint(throwStartPosition, throwMidPosition, throwEndPosition, t);
            transform.position = throwPosition;
        }
        else
        {
            animator.Play("Explosions");
        }
    }

    Vector3 CalculateBezierPoint(Vector3 start, Vector3 mid, Vector3 end, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * start;
        p += 3 * uu * t * mid;
        p += 3 * u * tt * mid;
        p += ttt * end;

        return p;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            enemyController.MakeHitPlayer();
        }
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }

    void OnCollider()
    {
        circleCollider2D.enabled = true;
    }
}
