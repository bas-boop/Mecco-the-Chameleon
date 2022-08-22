using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseManger : MonoBehaviour
{
    private GameObject _gm;
    private TimerManger _tm;
    [SerializeField] private string lastPlayerColor;
    [SerializeField] private int levelsFinished;
    [SerializeField] private TMP_Text highScoreText;

    [Header("Color's")]
    [SerializeField] private Color textColor;
    
    [SerializeField] private Color white;
    [SerializeField] private Color red;
    [SerializeField] private Color blue;
    [SerializeField] private Color yellow;
    [SerializeField] private Color green;
    [SerializeField] private Color orange;
    [SerializeField] private Color purple;
    [SerializeField] private Color brown;

    private void Awake()
    {
        _gm = GameObject.Find("Gamemanger");
        _tm = _gm.GetComponent<TimerManger>();
        levelsFinished = _tm.levelsSuccesede;
        lastPlayerColor = _tm.lastPlayerColor;
    }

    private void Start()
    {
        ChangeTextColor();
        
        highScoreText.text = levelsFinished.ToString();
        highScoreText.color = textColor;
    }

    private void ChangeTextColor()
    {
        if (lastPlayerColor == "White") textColor = white;
        else if (lastPlayerColor == "Red") textColor = red;
        else if (lastPlayerColor == "Orange") textColor = orange;
        else if (lastPlayerColor == "Yellow") textColor = yellow;
        else if (lastPlayerColor == "Green") textColor = green;
        else if (lastPlayerColor == "Blue") textColor = blue;
        else if (lastPlayerColor == "Purple") textColor = purple;
        else if (lastPlayerColor == "Brown") textColor = brown;
    }
}
