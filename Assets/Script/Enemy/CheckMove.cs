using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMove : MonoBehaviour
{
    private Vector3 startPos;
    [HideInInspector] public bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        isMove = currentPos != startPos;
        startPos = currentPos;
    }
}
