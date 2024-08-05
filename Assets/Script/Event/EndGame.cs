using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Start()
    {
        if(GameObject.Find("Player").GetComponent<PlayerHeal>().currentHeal > 0)
        {
            GameObject.Find("FillRed").SetActive(false);
            GameObject.Find("Result").GetComponent<TextMeshProUGUI>().text = "Chiến thắng";
        }else{
            GameObject.Find("Result").GetComponent<TextMeshProUGUI>().text = "Thất bại";
        }
        Time.timeScale = 0f;
    }
}
