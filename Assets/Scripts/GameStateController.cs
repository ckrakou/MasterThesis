using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateController : MonoBehaviour
{

    public int Gamestate = 0;
    public UnityEvent OneWorldMonumentVisited;
    public UnityEvent TwoWorldMonumentVisited;
    public UnityEvent ThreeWorldMonumentVisited;
    public UnityEvent FourWorldMonumentVisited;
    public UnityEvent FifthWorldMonumentVisited;

    

   void Awake(){
      GameStateManager.MasterGameState=Gamestate;
   }     
  
    public void TriggerWorldEvents(int state){
          switch(state){
                 case 1:
                 OneWorldMonumentVisited.Invoke();
                 //Debug.Log("1 Monument visited!");
                 break;
                  case 2:
                 TwoWorldMonumentVisited.Invoke();
                  //Debug.Log("2 Monuments visited!");
                 break;
                  case 3:
                 ThreeWorldMonumentVisited.Invoke();
                 //Debug.Log("3 Monuments visited!");
                 break;
                  case 4:
                 FourWorldMonumentVisited.Invoke();
                 //Debug.Log("4 Monuments visited!");
                 break;
                    case 5:
                 FifthWorldMonumentVisited.Invoke();
                 //Debug.Log("5 Monuments visited!");
                 break;
             }
    }

}
