using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    private GameObject _gameManger;

    private void Awake()
    {
        _gameManger = GameObject.Find("Gamemanger");
        Destroy(_gameManger);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("TestLevel");
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
