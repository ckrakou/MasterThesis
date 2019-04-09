using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public bool Debugging;
    public Image FadeImage;
    [HideInInspector]
    public float FadeTime;

    private void Awake()
    {
        //FadeImage.enabled = true;
    }

    public void FadeIn()
    {
        FadeImage.enabled = true;
        Color color = FadeImage.color;
        color.a = 1;
        FadeImage.color = color;
        FadeImage.DOFade(0f, FadeTime);
    }

    public void FadeOut()
    {
        FadeImage.enabled = true;
        FadeImage.DOFade(1f, FadeTime);
    }
}
