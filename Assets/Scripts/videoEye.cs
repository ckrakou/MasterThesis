using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class videoEye : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject VideoObject;

    public UnityEvent VideoEyeEvents;
    // Start is called before the first frame update
    void Start()
    {
        video.Prepare();
        VideoObject.SetActive(false);
    }

void Update(){
    if(Input.GetMouseButtonDown(0)){
        PlayEyeVideo();
    }
}

    public void PlayEyeVideo(){
        VideoEyeEvents.Invoke();
     VideoObject.SetActive(true);
       video.Play();
       float VideoLenght = (float)video.length;
       Destroy(gameObject,VideoLenght+0.2f);
     
    }
   
}
