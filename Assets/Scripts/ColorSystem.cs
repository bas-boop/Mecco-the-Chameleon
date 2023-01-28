using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSystem : MonoBehaviour
{
    #region Singleton
    private static ColorSystem _instance;
    
    public static ColorSystem Instance
    {
        get
        {
            if (_instance != null) return _instance;

            _instance = GameObject.FindObjectOfType<ColorSystem>();
            if (Instance != null) return _instance;

            GameObject container = new GameObject(typeof(ColorSystem).Name);
            _instance = container.AddComponent<ColorSystem>();

            return _instance;
        }
    }
    #endregion

    private GameObject _player;
    private SpriteRenderer _playerSprite;
    private Transform _playerPosition;
    
    [Header("Color's")]
    [SerializeField] private Color white;
    [SerializeField] private Color red;
    [SerializeField] private Color blue;
    [SerializeField] private Color yellow;
    [SerializeField] private Color green;
    [SerializeField] private Color orange;
    [SerializeField] private Color purple;
    [SerializeField] private Color brown;

    [Header("Particale's")]
    [SerializeField] private ParticleSystem whiteP;
    [SerializeField] private ParticleSystem redP;
    [SerializeField] private ParticleSystem blueP;
    [SerializeField] private ParticleSystem yellowP;
    [SerializeField] private ParticleSystem greenP;
    [SerializeField] private ParticleSystem orangeP;
    [SerializeField] private ParticleSystem purpleP;
    [SerializeField] private ParticleSystem brownP;

    private void Start()
    {
        _player = GameObject.Find("Beta Player");
        _playerSprite = _player.GetComponent<SpriteRenderer>();
        _playerPosition = _player.transform;
    }

    public void ChangeColor(string targetColor)
    {
        if (targetColor == "Red")
        {
            _playerSprite.color = red;
            _player.RemoveTag("White");
            _player.AddTag("Red");
            Instantiate(redP, _playerPosition);
        }
        else if (targetColor == "Blue")
        {
            _playerSprite.color = blue;
            _player.RemoveTag("White");
            _player.AddTag("Blue");
            Instantiate(blueP, _playerPosition);
        }
        else if (targetColor == "Yellow")
        {
            _playerSprite.color = yellow;
            _player.RemoveTag("White");
            _player.AddTag("Yellow");
            Instantiate(yellowP, _playerPosition);
        }
    }

    public void MixColor(string targetColor)
    {
        if (_player.GetTag(1) == "Red")
        {
            if (targetColor == "Blue")
            {
                _playerSprite.color = purple;
                _player.RemoveTag("Red");
                _player.AddTag("Purple");
                Instantiate(purpleP, _playerPosition);
            }
        }
        else if (_player.GetTag(1) == "Blue")
        {
            if (targetColor == "Red")
            {
                _playerSprite.color = purple;
                _player.RemoveTag("Blue");
                _player.AddTag("Purple");
                Instantiate(purpleP, _playerPosition);
            }
        }
        if (_player.GetTag(1) == "Blue")
        {
            if (targetColor == "Yellow")
            {
                _playerSprite.color = green;
                _player.RemoveTag("Blue");
                _player.AddTag("Green");
                Instantiate(greenP, _playerPosition);
            }
        }
        else if (_player.GetTag(1) == "Yellow")
        {
            if (targetColor == "Blue")
            {
                _playerSprite.color = green;
                _player.RemoveTag("Yellow");
                _player.AddTag("Green");
                Instantiate(greenP, _playerPosition);
            }
        }
        
        if (_player.GetTag(1) == "Yellow")
        {
            if (targetColor == "Red")
            {
                _playerSprite.color = orange;
                _player.RemoveTag("Yellow");
                _player.AddTag("Orange");
                Instantiate(orangeP, _playerPosition);
            }
        }
        else if (_player.GetTag(1) == "Red")
        {
            if (targetColor == "Yellow")
            {
                _playerSprite.color = orange;
                _player.RemoveTag("Red");
                _player.AddTag("Orange");
                Instantiate(orangeP, _playerPosition);
            }
        }
        
        if(_player.GetTag(1) == "Purple") 
            if (targetColor == "Yellow")
            {
                _playerSprite.color = brown;
                _player.RemoveTag("Purple");
                _player.AddTag("Brown");
                Instantiate(brownP, _playerPosition);
            }
        if(_player.GetTag(1) == "Green")
            if (targetColor == "Red")
            {
                _playerSprite.color = brown;
                _player.RemoveTag("Green");
                _player.AddTag("Brown");
                Instantiate(brownP, _playerPosition);
            }
        if(_player.GetTag(1) == "Orange")
            if (targetColor == "Blue")
            {
                _playerSprite.color = brown;
                _player.RemoveTag("Orange");
                _player.AddTag("Brown");
                Instantiate(brownP, _playerPosition);
            }
    }

    public void ResetColor()
    {
        _player.RemoveTag(1);
        _player.AddTag("White");
        
        Instantiate(whiteP, _playerPosition);
    }

    public Color White => white;
}
