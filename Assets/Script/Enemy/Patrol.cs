using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float timerPatrol = 0f;
    private bool isMove = true;
    private Vector3 limitPatrol;
    private CircleCollider2D circleCollider;
    private Vector3 startPosition;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        timerPatrol += Time.deltaTime;
        if (timerPatrol > 4f)
        {
            timerPatrol = 0f;
            limitPatrol = GetRandomPointInCircle();
            isMove = true;
        }
        if (isMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, limitPatrol, 1.5f * Time.deltaTime);
            if (Vector2.Distance(transform.position, limitPatrol) < 0.1f)
            {
                isMove = false;
            }
        }
    }

    Vector3 GetRandomPointInCircle()
    {
        Vector2 randomPoint = Random.insideUnitCircle * circleCollider.radius;
        return startPosition + new Vector3(randomPoint.x, randomPoint.y, 0);
    }
}
