using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private bool playerIsDead = false;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playerIsDead)
            {
                return;
            }

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
         GameIsPaused = true;
        Time.timeScale = 0f;
       
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
       
    }

    public void Restart2()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        playerIsDead = false; // Reset the playerIsDead flag
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void ShowPauseMenu()
    {
        if (!playerIsDead)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void SetPlayerDead(bool isDead)
    {
        playerIsDead = isDead;
        if (playerIsDead)
        {
            // Hide the resume button when the player is dead
            // Assuming you have a "Resume" button in the pauseMenuUI game object
            GameObject resumeButton = pauseMenuUI.transform.Find("ResumeBtn").gameObject;
            resumeButton.SetActive(false);
        }
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu Button Clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene"); 
    }
}
