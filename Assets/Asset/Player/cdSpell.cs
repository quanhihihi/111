using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cdSpell : MonoBehaviour
{
    Slider slider;
    public float maxCD;
    public bool checkCD;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        if (maxCD > 0)
        {
            slider.value = maxCD;
            maxCD -= Time.deltaTime;
        }

        if (maxCD > 0)
        {
            checkCD = false;
        }
        else
        {
            checkCD = true;
        }
    }
    public void setMaxCD(float maxCD)
    {
        slider.maxValue = maxCD;
        this.maxCD = maxCD;
    }
}
