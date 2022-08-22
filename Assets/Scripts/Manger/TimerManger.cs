using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManger : MonoBehaviour
{
    public float timer;
    private bool _losed = false;
    [SerializeField] private float startAmountTimer;
    public int levelsSuccesede;
    [SerializeField] private TMP_Text timerText;
    public string lastPlayerColor;

    private void Awake()
    {
        timer = startAmountTimer;
    }

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        string timeText = String.Format("{0:00}:{1:00}", minutes, seconds);
        return timeText;
    }
    
    private void Update()
    {
        if (_losed) return;
        
        if (timer < 0 && !_losed)
        {
            _losed = true;
            GameObject player = GameObject.Find("Beta Player");
            lastPlayerColor = player.GetTag(1);
            Destroy(player);
            timerText.enabled = false;
            SceneManager.LoadScene("Lose");
        }

        timer -= Time.deltaTime;
        timerText.text = FormatTime(timer);
    }
}
