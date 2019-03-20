using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpawnCollisionPreventerClocks : MonoBehaviour
{

   

    

    void Awake(){
     
    }
    
     void OnTriggerStay(Collider target)
     {
         if(target.tag == "WorldMonument")
         {
            transform.position=new Vector3(Random.Range(-500, 500),0,Random.Range(-500, 500));
            //Debug.Log("monuments moved!");
         }
     }


}
