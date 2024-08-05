using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicPoint : MonoBehaviour
{
    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void MaxMP(float maxMP)
    {
        slider.maxValue = maxMP;
    }

    public void UpdateMP(float currentMP)
    {

        slider.value = currentMP;

    }
}
