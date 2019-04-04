using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpawnCollisionPreventerMonsterCam : MonoBehaviour
{

    public GameObject Light; 
    public  GameObject Particles; 

    public GameObject WorldMonument;

    public AudioSource GlitchSound;
    public AudioSource Speak;

      public AudioSource MonsterSound;
    public GameObject MonsterCam;

    public GameObject PlayerCam;

    private bool OnlyBlinkOnce = true;





    void Awake(){
     
    }

  
  
    void Update(){

   
    }  

    void TurnOnMonsterCam(){
      PlayerCam.SetActive(false);
      MonsterCam.SetActive(true);
    }  
     void OnTriggerStay(Collider target)
     {
         if(target.tag == "WorldMonument")
         {
          //  transform.position=new Vector3(Random.Range(-100, 100),0,Random.Range(-100, 100));
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
      Speak.Play();
     Destroy(Light);
    Destroy(Particles);    
    StartCoroutine(RunMonsterCam(Speak.clip.length));
  
 }

IEnumerator RunMonsterCam(float SongTime){
  yield return new WaitForSeconds(SongTime+2);   
      PlayerCam.SetActive(false);
      MonsterCam.SetActive(true);
      MonsterSound.Play();

      yield return new WaitForSeconds(7); 
        PlayerCam.SetActive(true);
      MonsterCam.SetActive(false);
      MonsterSound.Stop();


}



}
