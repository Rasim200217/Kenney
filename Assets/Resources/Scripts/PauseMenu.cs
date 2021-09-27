using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject _pauseMenuUI;
    public static bool _gamePaused = false;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gamePaused)
            {
                ResumeGame();
            }else
            {
                Pause();
            }
        }
    }

   public void ResumeGame()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gamePaused = false;
    }

    public void RepeatGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gamePaused = true;
    }
}
