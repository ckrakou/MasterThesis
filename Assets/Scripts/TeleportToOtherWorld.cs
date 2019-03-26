using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToOtherWorld : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    public GameObject SuperHappyFunWorld;
   

    public void TeleportToFunWorld(){
            GameStateManager.IsPlayerInSuperFunWorld=true;
            SuperHappyFunWorld.gameObject.SetActive(true);
            Player.GetComponent<CharacterController>().enabled = false;
            
            Player.transform.position = new Vector3(-1, -200, -15);

    }

    public void TeleportToDepriWorld(){

       GameStateManager.IsPlayerInSuperFunWorld=false;
       GameStateManager.TimesInSuperFunWorld++;
      SuperHappyFunWorld.gameObject.SetActive(false);
        Player.GetComponent<CharacterController>().enabled = false;
        
            Player.transform.position = new Vector3(0, 10, 0);
    }

 void OnTriggerEnter(Collider target)
     {
         if(target.tag == "TeleportCollider")
         {
         
           TeleportToFunWorld();
         }
     }



  private void LateUpdate(){
         if (Player.GetComponent<CharacterController> ().enabled == false) {
            Player.GetComponent<CharacterController> ().enabled = true;
           
         }
     }




}
