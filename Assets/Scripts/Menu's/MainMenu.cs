using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject story;
    [SerializeField] private GameObject htp;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject backButton2;
    [SerializeField] private GameObject storyButton;

    private void Awake()
    {
        var gamemanger = GameObject.Find("Gamemanger");
        var player = GameObject.Find("Beta Player");
        if(gamemanger == null) return;
        Destroy(gamemanger);
        Destroy(player);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void StoryButton()
    {
        main.SetActive(false);
        story.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backButton);
    }
    
    public void HtpButton()
    {
        main.SetActive(false);
        htp.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backButton2);
    }

    public void BackButton()
    {
        story.SetActive(false);
        htp.SetActive(false);
        main.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(storyButton);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
