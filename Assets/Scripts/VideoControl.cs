using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    // Start is called before the first frame update

    public VideoPlayer video;
    public string VideoClipName;
    private bool videoBool = true;
    void Start()
    {
        //video.Prepare();
        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, VideoClipName);
        video.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(video.isPrepared &&videoBool){
            //playVideo();
            //videoBool=false;
        }
    }
    public void playVideo(){
        //video.Play();
    }

}
