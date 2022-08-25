using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyColorBlind : MonoBehaviour
{
    private GameObject _CBM;
    [SerializeField] private ColorBlindManger colorBlindManger;
    
    [SerializeField] private GameObject colorBlind;

    private void Awake()
    {
        _CBM = GameObject.Find("ColorBlind Manger");
        colorBlindManger = _CBM.GetComponent<ColorBlindManger>();
        
        if(colorBlindManger.GetColorBlind) colorBlind.SetActive(true);
        else if(!colorBlindManger.GetColorBlind) colorBlind.SetActive(false);
    }
}
