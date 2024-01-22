using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseGameScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public ControlsPanel controlsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            if (gameIsPaused)
            {
                resumeGame();
            }
            else 
            {
                pauseGame();
            }
        }
    }

    public void pauseGame()
    {
        controlsPanel.closeControlsPanel(); // ensure the buttons are active and not the controls panel

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }
    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
}
