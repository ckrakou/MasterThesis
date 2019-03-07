using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

using Kino;
public class DatamoshControl : MonoBehaviour
{

    public UnityEvent EnterDatamoshCollider;
    public UnityEvent ExitDatamoshCollider;

    public AudioClip[] DatamoshAudio;
    private AudioSource AudioPlayer;

    public GameObject FPSCam;

      void Start(){
          AudioPlayer= GetComponent<AudioSource>();
      }  


    // Start is called before the first frame update
   void OnTriggerEnter(Collider target)
     {
         if(target.tag == "DatamoshCollider")
         {
         EnterDatamoshCollider.Invoke();
         

        int RandomGlitchsound = Random.Range(0,DatamoshAudio.Length);
Debug.Log("Glitch! "+RandomGlitchsound);
            AudioPlayer.clip=DatamoshAudio[RandomGlitchsound];
            AudioPlayer.pitch=Random.Range(0.3f,1.5f);
            AudioPlayer.time=Random.Range(0.3f,30.5f);
            AudioPlayer.Play();            
            

         }
           if(target.tag == "AnalogGlitchCollider"){
             FPSCam.GetComponent<Kino.AnalogGlitch>().enabled=true;
               Debug.Log("Analog glitch!");
           }
           }
         



    
     void OnTriggerExit(Collider target)
     {
         if(target.tag == "DatamoshCollider")
         {
         ExitDatamoshCollider.Invoke();
         Debug.Log("Remove Glitch!");
         AudioPlayer.Stop();  
       

         }
          if(target.tag == "AnalogGlitchCollider"){
            FPSCam.GetComponent<Kino.AnalogGlitch>().enabled=false;
              Debug.Log("Remove Analog glitch");
        }
        


     }

}