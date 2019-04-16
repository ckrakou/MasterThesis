using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class videoEye : MonoBehaviour
{
    private VideoPlayer video;
    public GameObject[] VideoObjects;

    private int RandomVideo;
    private bool DestroyEverything = false;

    public UnityEvent VideoEyeEvents;
    // Start is called before the first frame update
    void Awake()
    {

        RandomVideo = Random.Range(0, 7);
        video = VideoObjects[RandomVideo].GetComponent<VideoPlayer>();
        for (int i = 0; i < 7; i++)
        {
            VideoObjects[i].GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, i+1 + ".mp4");
            VideoObjects[i].SetActive(false);
        }
    }

    void Update()
    {
        if (DestroyEverything)
        {
            if (!video.isPlaying)
            {
                Destroy(gameObject, 0.1f);
            }
        }
    }

    public void PlayEyeVideo()
    {
        VideoObjects[RandomVideo].SetActive(true);
        VideoEyeEvents.Invoke();
        DestroyEverything = true;



    }

}
