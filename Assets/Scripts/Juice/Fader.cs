﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour
{
    public float FadeTime = 2.5f;
    

    [Header("UI Elements")]
    public Image Overlay;
    [Range(0, 255)]
    public float OverlayAlpha = 1;

    public Button StartButton;
    [Range(0, 255)]
    public float StartButtonAlpha = 255;

    public Text Header;
    [Range(0, 255)]
    public float HeaderAlpha = 255;
    public Text Response;
    [Range(0,255)]
    public float ResponseAlpha = 255;

    public void FadeInPlayable()
    {
        StartButton.interactable = true;

        Overlay.DOFade(0, FadeTime);
        Header.DOFade(HeaderAlpha / 255, FadeTime).OnComplete(new TweenCallback(FadeInButton));
    }

    public void FadeInKeyFound(string response)
    {
        StartButton.interactable = false;
        Response.text = response;

        Overlay.DOFade(0, FadeTime);
        Header.DOFade(HeaderAlpha/255, FadeTime);
        FadeInResponseText();
    }

    public void FadeToBadFile(string response)
    {
        StartButton.interactable = false;
        Response.text = response;

        StartButton.image.DOFade(0, FadeTime).OnComplete(new TweenCallback(FadeInResponseText));
    }

    public void FadeOut()
    {
        StartButton.interactable = false;

        StartButton.GetComponent<Image>().DOFade(0, FadeTime);
        Header.DOFade(0, FadeTime);
        Response.DOFade(0, FadeTime).OnComplete(new TweenCallback(FadeOutOverlay));
    }

    /*
        Methods for fading in steps
    */

    private void FadeInResponseText()
    {
        Response.DOFade(ResponseAlpha / 255, FadeTime);
    }

    private void FadeInButton()
    {
        StartButton.image.DOFade(StartButtonAlpha / 255, FadeTime);
    }

    private void FadeOutOverlay()
    {
        Overlay.DOFade(OverlayAlpha / 255, FadeTime);
    }
}
