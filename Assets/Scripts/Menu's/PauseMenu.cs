using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject ps;
    [SerializeField] private bool isPaused;

    private void Awake()
    {
        Time.timeScale = 1f;
        isPaused = false;
        ps.SetActive(false);
    }

    private void Update()
    {
        Toggle();
    }

    private void Toggle()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (!isPaused)
            {
                ps.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }else
            {
                ps.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }

        if (!isPaused)
        {
            ps.SetActive(false);
        }
    }

    public void ResumeButton()
    {
        ps.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void ManiMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
