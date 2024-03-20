using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKodlar2 : MonoBehaviour
{
    public GameObject UI;
    public GameObject ContinueButton;
    public GameObject ExitGameButton;
    private bool isPaused;

    public void ContinueGame()
    {
        UI.SetActive(false);
        Time.timeScale = 1;
        Invoke(nameof(StatusChanged), 0.2f);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void StatusChanged()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public void PauseGame()
    {
        UI.SetActive(true);
        Time.timeScale = 0;
        StatusChanged();
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
