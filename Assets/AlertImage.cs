using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AlertImage : MonoBehaviour
{
    public Image image;
    Color mainColor = new Color32(255, 183, 95, 255);
    Color initColor = new Color32(255, 183, 95, 0);
    
    public void SetVisible()
    {
        image.material.DOColor(mainColor, 0.5f);
        Debug.Log("alert image enabled, setting color to" + mainColor);
    }

    public void ExitVisible()
    {
        image.material.DOColor(initColor, 0.5f);
        Debug.Log("alert image disabled");
    }
}
