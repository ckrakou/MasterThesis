using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpawnCollisionPreventer : MonoBehaviour
{
    
     void OnTriggerStay(Collider target)
     {
         if(target.tag == "WorldMonument")
         {
            transform.position=new Vector3(Random.Range(-2000, 2000),0,Random.Range(-2000, 2000));
            Debug.Log("monuments moved!");
         }
     }


}
