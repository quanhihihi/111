using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCutscene : MonoBehaviour
{
    Dialog dialog;
    GameObject[] enemy;
    GameObject audioTheme;
    float cameraSize;
    bool stateCam, statePlay = false;

    void Awake()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        dialog = GetComponent<Dialog>();
        GameObject.Find("Player").GetComponent<PlayerMove>().enabled = false;
        GameObject.Find("AimPoint").GetComponent<PrefabBullet>().enabled = false;
        GameObject.Find("AimPoint").GetComponent<PrefabSkill>().enabled = false;
        audioTheme = GameObject.Find("BackGroundMusic");
    }

    void Start()
    {
        // Camera settings
        Camera.main.orthographicSize = 3.8f;
        cameraSize = Camera.main.orthographicSize;
        audioTheme.SetActive(false);
        EventEnemy(true);

        // Start level cutscene
        StartLevelCutscene();
    }

    public void StartLevelCutscene()
    {
        // Hide the menu
        Destroy(GameObject.Find("Menu"));

        // Show dialog box
        Instantiate(Resources.Load<GameObject>("Prefab/UI/Dialog/DialogBox")).transform.SetParent(GameObject.Find("UI").transform, false);

        statePlay = true;
    }

    void Update()
    {
        if (stateCam)
        {
            SetCamera();
        }
        if (statePlay)
        {
            if (FindAnyObjectByType<DialogBox>() == null)
            {
                audioTheme.SetActive(true);
                EndLevelCutscene();
                statePlay = false;
            }
        }
    }

    void EndLevelCutscene()
    {
        GameObject.Find("Player").GetComponent<PlayerMove>().enabled = true;
        GameObject.Find("AimPoint").GetComponent<PrefabBullet>().enabled = true;
        GameObject.Find("AimPoint").GetComponent<PrefabSkill>().enabled = true;
        stateCam = true;
        EventEnemy(false);
    }

    void SetCamera()
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 8f, 0.8f * Time.deltaTime);
        if (Camera.main.orthographicSize > 7.999f)
        {
            stateCam = false;
        }
    }

    void EventEnemy(bool state)
    {
        if (state)
            foreach (GameObject e in enemy)
            {
                e.SetActive(false);
            }
        else
            foreach (GameObject e in enemy)
            {
                e.SetActive(true);
            }
    }
}
