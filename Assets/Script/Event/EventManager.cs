using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    GameObject player;
    bool check = true, checkScene;
    private void Start()
    {
        player = GameObject.Find("Player");
        checkScene = CheckCountScene();
    }
    private void Update()
    {
        if (player.GetComponent<PlayerHeal>().currentHeal <= 0 && check || checkScene && GameObject.FindGameObjectWithTag("Enemy") == null && check)
        {
            Instantiate(Resources.Load<GameObject>("Prefab/Event/EndGame")).transform.SetParent(GameObject.Find("UI").transform, false);
            check = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.Find("PauseGame(Clone)") == null)
            {
                Instantiate(Resources.Load<GameObject>("Prefab/Event/PauseGame")).transform.SetParent(GameObject.Find("UI").transform, false);
            }
        }
    }

    private bool CheckCountScene()
    {
        int currentCount = SceneManager.GetActiveScene().buildIndex;
        int lastCount = SceneManager.sceneCountInBuildSettings - 1;
        return lastCount == currentCount;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.Find("PauseGame(Clone)"));
    }
}
