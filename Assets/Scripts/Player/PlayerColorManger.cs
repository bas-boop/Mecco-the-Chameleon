using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorManger : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private AudioSource water;

    [Header("Bools")]
    [SerializeField] private bool hasAColor = false;
    
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
    
    private void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        gameObject.AddTag("White");
        hasAColor = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.HasTag("Door") || col.gameObject.HasTag("Checkpoint")) return;
        
        if(!hasAColor) ChangeColor(col);
        if (hasAColor) MixColor(col);
        if (hasAColor && playerSprite.color != white) ResetColor(col);
    }

    private void ChangeColor(Collider2D col)
    {
        if (col.gameObject.HasTag("Red"))
        {
            playerSprite.color = red;
            gameObject.RemoveTag("White");
            gameObject.AddTag("Red");
            Instantiate(redP, gameObject.transform);
        }
        else if (col.gameObject.HasTag("Blue"))
        {
            playerSprite.color = blue;
            gameObject.RemoveTag("White");
            gameObject.AddTag("Blue");
            Instantiate(blueP, gameObject.transform);
        }
        else if (col.gameObject.HasTag("Yellow"))
        {
            playerSprite.color = yellow;
            gameObject.RemoveTag("White");
            gameObject.AddTag("Yellow");
            Instantiate(yellowP, gameObject.transform);
        }
        
        PlaySound();
        hasAColor = true;

        //voor de zekerheid, want als je wit bent en wit aan raakt, dan wordt hasAColor true
        if (col.gameObject.HasTag("White"))
        {
            hasAColor = false;
        }
    }
    private void MixColor(Collider2D col)
    {
        if (playerSprite.color == red)
        {
            if (col.gameObject.HasTag("Blue"))
            {
                playerSprite.color = purple;
                gameObject.RemoveTag("Red");
                gameObject.AddTag("Purple");
                Instantiate(purpleP, gameObject.transform);
            }
        }
        else if (playerSprite.color == blue)
        {
            if (col.gameObject.HasTag("Red"))
            {
                playerSprite.color = purple;
                gameObject.RemoveTag("Blue");
                gameObject.AddTag("Purple");
                Instantiate(purpleP, gameObject.transform);
            }
        }
        
        if (playerSprite.color == blue)
        {
            if (col.gameObject.HasTag("Yellow"))
            {
                playerSprite.color = green;
                gameObject.RemoveTag("Blue");
                gameObject.AddTag("Green");
                Instantiate(greenP, gameObject.transform);
            }
        }
        else if (playerSprite.color == yellow)
        {
            if (col.gameObject.HasTag("Blue"))
            {
                playerSprite.color = green;
                gameObject.RemoveTag("Yellow");
                gameObject.AddTag("Green");
                Instantiate(greenP, gameObject.transform);
            }
        }
        
        if (playerSprite.color == yellow)
        {
            if (col.gameObject.HasTag("Red"))
            {
                playerSprite.color = orange;
                gameObject.RemoveTag("Yellow");
                gameObject.AddTag("Orange");
                Instantiate(orangeP, gameObject.transform);
            }
        }
        else if (playerSprite.color == red)
        {
            if (col.gameObject.HasTag("Yellow"))
            {
                playerSprite.color = orange;
                gameObject.RemoveTag("Red");
                gameObject.AddTag("Orange");
                Instantiate(orangeP, gameObject.transform);
            }
        }
        
        if(playerSprite.color == purple) 
            if (col.gameObject.HasTag("Yellow"))
            {
                playerSprite.color = brown;
                gameObject.RemoveTag("Purple");
                gameObject.AddTag("Brown");
                Instantiate(brownP, gameObject.transform);
            }
        if(playerSprite.color == green)
            if (col.gameObject.HasTag("Red"))
            {
                playerSprite.color = brown;
                gameObject.RemoveTag("Green");
                gameObject.AddTag("Brown");
                Instantiate(brownP, gameObject.transform);
            }
        if(playerSprite.color == orange)
            if (col.gameObject.HasTag("Blue"))
            {
                playerSprite.color = brown;
                gameObject.RemoveTag("Orange");
                gameObject.AddTag("Brown");
                Instantiate(brownP, gameObject.transform);
            }
        PlaySound();
    }
    private void ResetColor(Collider2D col)
    {
        if (col.gameObject.HasTag("White"))
        {
            hasAColor = false;

            playerSprite.color = white;

            gameObject.RemoveTag(1);
            gameObject.AddTag("White");
            
            Instantiate(whiteP, gameObject.transform);
            PlaySound();
        }
    }

    private void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
