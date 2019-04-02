using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportToOtherWorld : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    public GameObject SuperHappyFunWorld;

    public UnityEvent GoToFunWorld; 
   
   public UnityEvent LeaveFunWorld; 

    public void TeleportToFunWorld(){
            GameStateManager.IsPlayerInSuperFunWorld=true;
            SuperHappyFunWorld.gameObject.SetActive(true);
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = new Vector3(-1, -200, -15);
            GoToFunWorld.Invoke();
    }

    public void TeleportToDepriWorld(){

       GameStateManager.IsPlayerInSuperFunWorld=false;
       GameStateManager.TimesInSuperFunWorld++;
      SuperHappyFunWorld.gameObject.SetActive(false);
        Player.GetComponent<CharacterController>().enabled = false;
        
            Player.transform.position = new Vector3(0, 10, 0);
            LeaveFunWorld.Invoke();
    }

 void OnTriggerEnter(Collider target)
     {
         if(target.tag == "TeleportCollider")
         {
         if(GameStateManager.TimesInSuperFunWorld<4){
           TeleportToFunWorld();
         }
           Destroy(target.gameObject);
         }
         
     }



  private void LateUpdate(){
         if (Player.GetComponent<CharacterController> ().enabled == false) {
            Player.GetComponent<CharacterController> ().enabled = true;
           
         }
     }




}
