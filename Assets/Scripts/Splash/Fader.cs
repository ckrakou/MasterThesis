using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Fader : MonoBehaviour
{
    public bool Debugging;
    public Image FadeImage;
    public Text[] Text;
    [HideInInspector]
    public float FadeTime;

    private float initialTextAlpha;

    private void Awake()
    {
        //FadeImage.enabled = true;
        initialTextAlpha = Text[0].color.a;
        foreach (var text in Text)
        {
            Color c = text.color;
            c.a = 0;
            text.color = c;
        }
    }

    public void FadeIn()
    {

        FadeImage.enabled = true;
        Color color = FadeImage.color;
        color.a = 1;

        FadeImage.color = color;
        FadeImage.DOFade(0f, FadeTime).onComplete+=new TweenCallback(FadeInText);


    }

    public void FadeInText()
    {
        foreach (var text in Text)
        {
            text.DOFade(initialTextAlpha, FadeTime);
        }

    }

    public void FadeOut()
    {
        FadeImage.enabled = true;
        FadeImage.DOFade(1f, FadeTime).onComplete=new TweenCallback(FadeOutText);
    }

    public void FadeOutText()
    {
        foreach (var text in Text)
        {
            text.DOFade(0, FadeTime);
        }

    }
}
