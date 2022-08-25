using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlindManger : MonoBehaviour
{
    [SerializeField] private bool colorBlind;
    private SetColorBlindMode _SCBM;

    public bool GetColorBlind => colorBlind;
    
    private void Update()
    {
        if(GameObject.Find("SetColorblindMode") == null) return;
        
        var SCBM = GameObject.Find("SetColorblindMode");
        _SCBM = SCBM.GetComponent<SetColorBlindMode>();

        colorBlind = _SCBM.color;
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ColorBlindManger");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
