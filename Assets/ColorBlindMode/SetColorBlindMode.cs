using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorBlindMode : MonoBehaviour
{
    public bool color;

    public void SetBool()
    {
        if (!color) color = true;
        else color = false;
    }
}
