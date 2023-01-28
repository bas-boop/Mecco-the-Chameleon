using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerColorManger : MonoBehaviour
{
    private AudioSource _pickupSound;
    private ColorMediator _colorMediator;

    [Header("Refrence")]
    [SerializeField] private SpriteRenderer playerSprite;

    [Header("Bools")]
    [SerializeField] private bool hasAColor = false;

    [Header("Events")]
    [SerializeField] private UnityEvent onChangeColor = new UnityEvent();
    [SerializeField] private UnityEvent onMixColor = new UnityEvent();
    [SerializeField] private UnityEvent onResetColor = new UnityEvent();

    private void Awake()
    {
        _pickupSound = GetComponent<AudioSource>();
        playerSprite = GetComponent<SpriteRenderer>();
        _colorMediator = GetComponent<ColorMediator>();
        gameObject.AddTag("White");
        hasAColor = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.HasTag("Door") || col.gameObject.HasTag("Checkpoint")) return;

        // _currentColor = gameObject.GetTag(1);
        var targetColor = col.gameObject.GetTag(0);

        if (!hasAColor) ChangeColor(targetColor);
        else if (hasAColor) MixColor(targetColor);
        else if (hasAColor && playerSprite.color != ColorSystem.Instance.White) ResetColor();
    }

    private void ChangeColor(string targetColor)
    {
        onChangeColor.AddListener(_colorMediator.ChangeColor(targetColor));

        hasAColor = true;

        //voor de zekerheid, want als je wit bent en wit aan raakt, dan wordt hasAColor true
        if (targetColor == "White") hasAColor = false;

        PlaySound();
        onMixColor.RemoveAllListeners();
    }
    private void MixColor(string targetColor)
    {
        onMixColor.AddListener(_colorMediator.MixColor(targetColor));
        PlaySound();
        onMixColor.RemoveAllListeners();
    }
    
    private void ResetColor()
    {
        onResetColor?.Invoke();
        hasAColor = false;
        PlaySound();
    }

    private void PlaySound()
    {
        _pickupSound.Play();
    }
}
