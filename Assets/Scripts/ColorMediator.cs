using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorMediator : MonoBehaviour
{
    public UnityAction ChangeColor(string targetColor)
    {
        ColorSystem.Instance.ChangeColor(targetColor);
        return null;
    }

    public UnityAction MixColor(string targetColor)
    {
        ColorSystem.Instance.MixColor(targetColor);
        return null;
    }

    public void ResetColor()
    {
        ColorSystem.Instance.ResetColor();
    }
}
