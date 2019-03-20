using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpawnCollisionPreventer : MonoBehaviour
{

    public GameObject Light; 
    public  GameObject Particles; 

    public GameObject WorldMonument;

    private bool OnlyBlinkOnce = true;
    
     void OnTriggerStay(Collider target)
     {
         if(target.tag == "WorldMonument")
         {
            transform.position=new Vector3(Random.Range(-500, 500),0,Random.Range(-500, 500));
            //Debug.Log("monuments moved!");
         }
     }
      void OnTriggerEnter(Collider target)
     {
         if(target.tag == "Player")
         {
            Destroy(Light);
             Destroy(Particles);
             if(OnlyBlinkOnce){
             StartCoroutine(Blink());
             OnlyBlinkOnce=false;
             }
         }
     }

       IEnumerator Blink() {
       WorldMonument.GetComponent<Renderer>().enabled=false;
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       
 
   WorldMonument.GetComponent<Renderer>().enabled=true;
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       

    WorldMonument.GetComponent<Renderer>().enabled=false;      
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));

    WorldMonument.GetComponent<Renderer>().enabled=true;
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f)); 
    
         WorldMonument.GetComponent<Renderer>().enabled=false;
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       
 
   WorldMonument.GetComponent<Renderer>().enabled=true;
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));       

    WorldMonument.GetComponent<Renderer>().enabled=false;      
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f));

    WorldMonument.GetComponent<Renderer>().enabled=true;
    yield return new WaitForSeconds(Random.Range(0.05f,0.5f)); 
      
 }


}
