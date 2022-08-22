using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] private string doorColor;

    [SerializeField] private BoxCollider2D boxCollider2D;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.HasTag("Player"))
        {
            if (col.gameObject.HasTag(doorColor))
            {
                boxCollider2D.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        boxCollider2D.enabled = true;
    }
}
