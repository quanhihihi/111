using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void MaxHeal(float maxHeal)
    {
        slider.maxValue = maxHeal;
    }

    public void UpdateHeal(float currentHeal)
    {

        slider.value = currentHeal;

    }
}