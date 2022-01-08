using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMAnger : MonoBehaviour
{
    public GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
