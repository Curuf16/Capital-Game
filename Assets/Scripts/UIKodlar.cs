using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKodlar : MonoBehaviour
{
    public GameObject UI;
    public GameObject ContinueButton;
    public GameObject StartButton;
    private bool isPausedLocal;
    private bool isMuted;


    public bool isPaused
    {
        get
        {
            return isPausedLocal;
        }
        set
        {
            isPausedLocal = value;
        }
    }


    private void Start()
    {
        
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
        AudioListener.pause = true;
        UI.SetActive(true);
        StartButton.SetActive(false);
        ContinueButton.SetActive(true);
        Time.timeScale = 0f;
        StatusChanged();
    }

    public void ContinueGame()
    {
        AudioListener.pause = false;
        UI.SetActive(false);
        Time.timeScale = 1f;
        Invoke(nameof(StatusChanged), 0.2f);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
