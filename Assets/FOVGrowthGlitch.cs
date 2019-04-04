using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FOVGrowthGlitch : MonoBehaviour
{
    public GameObject Player;
    public UnityEvent Shrink;
     public UnityEvent BackToNormal;

    private bool GrowthBool = false;
     private bool GrowthSwitch = true;

    private float growth=0;
    void OnTriggerEnter(Collider target)
     {
         if(target.tag == "GrowthCollider")
         {
             StartCoroutine(StartGrowing());
             Shrink.Invoke();
             Debug.Log("shrink!");
         }
         
     }

    

     IEnumerator StartGrowing(){
    Player.GetComponent<Camera>().fieldOfView=30;
    Player.transform.localPosition=new Vector3(0, 0.04f ,0); 
        yield return new WaitForSeconds(Random.Range(2,6)); 

       Player.GetComponent<Camera>().fieldOfView=30;
       Player.transform.localPosition=new Vector3(0, 0.8f ,0); 
       BackToNormal.Invoke();
       Debug.Log("stop shrink!");
     }
    
}
