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

   
   

    public GameObject FPSCam;

      void Start(){
         
      }  


    // Start is called before the first frame update
   void OnTriggerEnter(Collider target)
     {
         if(target.tag == "DatamoshCollider")
         {
         EnterDatamoshCollider.Invoke();
         

            
            

         }
           if(target.tag == "AnalogGlitchCollider"){
             FPSCam.GetComponent<Kino.AnalogGlitch>().enabled=true;
              FPSCam.GetComponent<Kino.AnalogGlitch>().scanLineJitter = Random.Range(01f,0.95f);
              FPSCam.GetComponent<Kino.AnalogGlitch>().horizontalShake = Random.Range(01f,0.95f);
              FPSCam.GetComponent<Kino.AnalogGlitch>().verticalJump = Random.Range(01f,0.95f);
              FPSCam.GetComponent<Kino.AnalogGlitch>().colorDrift = Random.Range(01f,0.95f);

               Debug.Log("Analog glitch!");
           }
           }
         



    
     void OnTriggerExit(Collider target)
     {
         if(target.tag == "DatamoshCollider")
         {
         ExitDatamoshCollider.Invoke();
         Debug.Log("Remove Glitch!");
         }
          if(target.tag == "AnalogGlitchCollider"){
            FPSCam.GetComponent<Kino.AnalogGlitch>().enabled=false;
              Debug.Log("Remove Analog glitch");
        }
        


     }

}