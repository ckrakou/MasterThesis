﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class worldSpawnCollisionPreventerTV : MonoBehaviour
{

    public GameObject Light;
    public GameObject Particles;

    public GameObject WorldMonument;

    public AudioSource GlitchSound;
    public VideoPlayer video;

     public GameObject GameControl;
 public GameObject UI;

 public int SignNumber;

    private bool OnlyBlinkOnce = true;



    void Start()
    {
        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, "TVShows.webm");
        video.Prepare();
    }

    void OnTriggerStay(Collider target)
    {
        if (target.tag == "WorldMonument")
        {
            //transform.position=new Vector3(Random.Range(-100, 100),0,Random.Range(-100, 100));
            //Debug.Log("monuments moved!");
        }
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {

            if (OnlyBlinkOnce)
            {
                   GameStateManager.MasterGameState++;
                GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                UI.GetComponent<UI>().ChangeSign(SignNumber); 
                StartCoroutine(Blink());
                OnlyBlinkOnce = false;
            }
        }
    }

    IEnumerator Blink()
    {


        for (int i = 0; i < 11; i++)
        {
            WorldMonument.GetComponent<Renderer>().enabled = false;
            Particles.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.5f));

            WorldMonument.GetComponent<Renderer>().enabled = true;
            Particles.GetComponent<Renderer>().enabled = true;
            GlitchSound.pitch = Random.Range(0.9f, 1.9f);
            GlitchSound.Play();
            yield return new WaitForSeconds(Random.Range(0.05f, 0.5f));
        }

        GlitchSound.Stop();
        video.Play();
        Destroy(Light);
        Destroy(Particles);



    }


}
