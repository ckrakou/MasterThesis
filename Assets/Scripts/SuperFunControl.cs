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
      public UnityEvent SecondTimeStartToLeave;

        public UnityEvent ThirdTimeStartToLeave;

    public UnityEvent TeleportToDepriWorld;
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
    void OnEnable()
    {
      //Post.profile=DepriPost;
      SetupFunworld();
       if(GameStateManager.TimesInSuperFunWorld==1){
              StartCoroutine(StuffThatHappensBeforeReturningFirstTime(5,3));
        }
         if(GameStateManager.TimesInSuperFunWorld==2){
              StartCoroutine(StuffThatHappensBeforeReturningSecondTime(5,3));
        }
         if(GameStateManager.TimesInSuperFunWorld==3){
              StartCoroutine(StuffThatHappensBeforeReturningThirdTime(5,3));
        }
    }

    private void ReturnToOtherWorld(){
        
    //set up the graphics for depri world
        Post.profile=DepriPost;
       RenderSettings.skybox=DepriSkybox;
       PlayerCam.GetComponent<Tube>().enabled=true;
       PlayerCam.GetComponent<AnalogGlitch>().enabled=false;
       UI.gameObject.SetActive(true);
       //call teleport funtion from teleport script
       TeleportToDepriWorld.Invoke();

        

    }

      IEnumerator StuffThatHappensBeforeReturningFirstTime(int TimeBeforeGlitches, int timeToReturn){
        yield return new WaitForSeconds(TimeBeforeGlitches); 
        //start glitches and music before leaving
        FirstTimeStartToLeave.Invoke(); 
        PlayerCam.GetComponent<AnalogGlitch>().enabled=true;
        yield return new WaitForSeconds(timeToReturn);  
        //call leave function
       ReturnToOtherWorld();    

    }
       IEnumerator StuffThatHappensBeforeReturningSecondTime(int TimeBeforeGlitches, int timeToReturn){
        yield return new WaitForSeconds(TimeBeforeGlitches); 
        //start glitches and music before leaving
        SecondTimeStartToLeave.Invoke(); 
        PlayerCam.GetComponent<AnalogGlitch>().enabled=true;
        yield return new WaitForSeconds(timeToReturn);  
        //call leave function
       ReturnToOtherWorld();    

    }
       IEnumerator StuffThatHappensBeforeReturningThirdTime(int TimeBeforeGlitches, int timeToReturn){
        yield return new WaitForSeconds(TimeBeforeGlitches); 
        //start glitches and music before leaving
        ThirdTimeStartToLeave.Invoke(); 
        PlayerCam.GetComponent<AnalogGlitch>().enabled=true;
        yield return new WaitForSeconds(timeToReturn);  
        //call leave function
       ReturnToOtherWorld();    

    }

    void SetupFunworld(){
        //set up basic graphic for fun world
        Post.profile=HappyPost;
       RenderSettings.skybox=HappySkybox;
       PlayerCam.GetComponent<Tube>().enabled=false;
       UI.gameObject.SetActive(false);

    }

}
