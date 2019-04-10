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
    public Text Welcome;
    public Text Response;
    public Image Button;
    public Image Background;
    public Image Header;

    //public Text[] Text;
    [HideInInspector]
    public float FadeTime;

    private float initialTextAlpha;
    private string response;

    private void Awake()
    {
        //FadeImage.enabled = true;
        initialTextAlpha = Welcome.color.a;
       
            Color c = Welcome.color;
            c.a = 0;


        Welcome.color = c;
        Response.color = c;
        //Button.color = c;
    }

    public void FadeIn()
    {

        FadeImage.enabled = true;
        Color color = FadeImage.color;
        color.a = 1;

        FadeImage.color = color;
        FadeImage.DOFade(0f, FadeTime).onComplete += new TweenCallback(FadeInText);

        Button.DOFade(initialTextAlpha, FadeTime);
        Header.DOFade(255, FadeTime);
        //Response.text = "";
        //Response.DOFade(0, FadeTime);

    }

    public IEnumerator FadeResponse(string response)
    {
        this.response = response;
        Debug.Log("RESPONSE IS NOW " + response);

        Color c = Response.color;
        c.a = 0;
        Response.color = c;

        Button.DOFade(0, FadeTime);
        Response.text = response;
        
        Button.gameObject.GetComponent<Button>().interactable = false;



        yield return new WaitForSeconds(FadeTime);
        Response.DOFade(initialTextAlpha, FadeTime);


        
    }


    public void FadeInText()
    {

        Button.DOFade(initialTextAlpha, FadeTime);
        Welcome.DOFade(initialTextAlpha, FadeTime);
        Response.DOFade(initialTextAlpha, FadeTime);


    }

    public void FadeOut()
    {
        FadeImage.enabled = true;
        FadeImage.DOFade(1f, FadeTime).onComplete = new TweenCallback(FadeOutText);
    }

    public void FadeOutText()
    {

        Button.DOFade(0, FadeTime);
       Welcome.DOFade(0, FadeTime);
       Response.DOFade(0, FadeTime);
        Background.DOFade(1, FadeTime);
        Header.DOFade(0, FadeTime);


    }

    private IEnumerator FadeBackground()
    {
        yield return new WaitForSeconds(FadeTime);
        Background.DOFade(1, FadeTime);
    }
}
