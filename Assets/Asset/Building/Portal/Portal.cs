using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public String nameScene;
    SpriteRenderer sprite;
    float timer = 0f, a = 0f, temp = 1;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            ChangeColorA();
        else
            ColorA(0f);
    }

    void ChangeColorA()
    {
        if (timer > 0.1f)
        {
            if (a >= 0.3f)
                temp = -1;
            else if (a <= 0f)
                temp = 1;
            timer = 0f;
            ColorA(a);
            a += 0.02f * temp;
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene(nameScene);
        }
    }

    void ColorA(float a)
    {
        Color color = sprite.color;
        color.a = a;
        sprite.color = color;
    }
}
