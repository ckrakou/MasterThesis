using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SafetyNet : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject PlayerPrefab;

   public UnityEvent HitSaftynet;
    public UnityEvent BackAtSquareOne;

     void OnTriggerEnter(Collider target)
     {
         if(target.tag == "Player")
         {
          //Debug.Log("hit saftynet");
           HitSaftynet.Invoke();

          PlayerPrefab.GetComponent<CharacterController>().enabled = false;
            
            PlayerPrefab.transform.position = new Vector3(0, 3, 0);
            StartCoroutine(StopGlitch());
           
         }
     }

     IEnumerator StopGlitch(){

    yield return new WaitForSeconds(Random.Range(2f,3f));
    BackAtSquareOne.Invoke();

     }
    private void LateUpdate(){
         if (PlayerPrefab.GetComponent<CharacterController> ().enabled == false) {
            PlayerPrefab.GetComponent<CharacterController> ().enabled = true;
           
         }
     }
}
