using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpawnCollisionPreventer : MonoBehaviour
{

    public GameObject Light; 
    public  GameObject Particles; 

    public GameObject WorldMonument;

    public AudioSource GlitchSound;

    private bool OnlyBlinkOnce = true;



    void Awake(){
     
    }
    
     void OnTriggerStay(Collider target)
     {
         if(target.tag == "WorldMonument")
         {
            transform.position=new Vector3(Random.Range(-300, 300),0,Random.Range(-300, 300));
            //Debug.Log("monuments moved!");
         }
     }
      void OnTriggerEnter(Collider target)
     {
         if(target.tag == "Player")
         {
          
             if(OnlyBlinkOnce){
             StartCoroutine(Blink());
             OnlyBlinkOnce=false;
             }
         }
     }

       IEnumerator Blink() {

       WorldMonument.GetComponent<Renderer>().enabled=false;
         Particles.GetComponent<Renderer>().enabled=false;
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       
 
   WorldMonument.GetComponent<Renderer>().enabled=true;
         Particles.GetComponent<Renderer>().enabled=true;
         GlitchSound.pitch = Random.Range(0.9f,1.9f);
   GlitchSound.Play();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       

      WorldMonument.GetComponent<Renderer>().enabled=false;
         Particles.GetComponent<Renderer>().enabled=false;
          GlitchSound.Pause();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       
 
   WorldMonument.GetComponent<Renderer>().enabled=true;
         Particles.GetComponent<Renderer>().enabled=true;
         GlitchSound.pitch = Random.Range(0.9f,1.9f);
   GlitchSound.Play();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));  

       WorldMonument.GetComponent<Renderer>().enabled=false;
         Particles.GetComponent<Renderer>().enabled=false;
         GlitchSound.Pause();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       
 
   WorldMonument.GetComponent<Renderer>().enabled=true;
         Particles.GetComponent<Renderer>().enabled=true;
         GlitchSound.pitch = Random.Range(0.9f,1.9f);
   GlitchSound.Play();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));  

       WorldMonument.GetComponent<Renderer>().enabled=false;
         Particles.GetComponent<Renderer>().enabled=false;
         GlitchSound.Pause();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       
 
   WorldMonument.GetComponent<Renderer>().enabled=true;
         Particles.GetComponent<Renderer>().enabled=true;
         GlitchSound.pitch = Random.Range(0.9f,1.9f);
   GlitchSound.Play();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));  

       WorldMonument.GetComponent<Renderer>().enabled=false;
         Particles.GetComponent<Renderer>().enabled=false;
         GlitchSound.Pause();
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       
 
   WorldMonument.GetComponent<Renderer>().enabled=true;
         Particles.GetComponent<Renderer>().enabled=true;
         GlitchSound.pitch = Random.Range(0.9f,1.9f);
    GlitchSound.Play();
  

    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));      
   GlitchSound.Stop();
     Destroy(Light);
    Destroy(Particles);
     
    
      
 }


}
