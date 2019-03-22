using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using Kino;
using UnityEngine.UI;
public class SuperFunControl : MonoBehaviour
{
    
    public UnityEvent FirstTimeStartToLeave;
    public GameObject PlayerPrefab;
    
    public Camera PlayerCam;

    public PostProcessVolume Post;
    public PostProcessProfile HappyPost;
    public PostProcessProfile DepriPost;

    public Material DepriSkybox;
    public Material HappySkybox;

    public Canvas UI;

    public int FirstVisitTime = 5; 
   

    private float TimeInFunworld;
    // Start is called before the first frame update
    void Start()
    {
      Post.profile=DepriPost;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameStateManager.IsPlayerInSuperFunWorld){

            SetupFunworld();
        }
        
        TimeInFunworld=+Time.deltaTime;
    if(GameStateManager.TimesInSuperFunWorld==1){
        if(FirstVisitTime > TimeInFunworld){
            Debug.Log("working");
            FirstTimeStartToLeave.Invoke();
            StartCoroutine(ReturnToOtherWorld(4));

        }


    }


    }
    IEnumerator ReturnToOtherWorld(int TimeToWait){
        yield return new WaitForSeconds(TimeToWait);  

            Post.profile=DepriPost;
       RenderSettings.skybox=DepriSkybox;
       PlayerCam.GetComponent<Tube>().enabled=true;
       UI.gameObject.SetActive(true);
     
        

    }

    void SetupFunworld(){
        Post.profile=HappyPost;
       RenderSettings.skybox=HappySkybox;
       PlayerCam.GetComponent<Tube>().enabled=false;
       UI.gameObject.SetActive(false);

    }

}
