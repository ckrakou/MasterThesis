using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateCollider : MonoBehaviour
{
    public GameObject GameControl;
    public GameObject UI;
  

    private bool WMNotVisited1=true,WMNotVisited2=true,WMNotVisited3=true,WMNotVisited4=true,WMNotVisited5=true,WMNotVisited6=true,WMNotVisited7=true;
  
  /* 
    void OnTriggerEnter(Collider target)
     {
         if(target.name == "WorldMonument1")
         {
                if(WMNotVisited1){
                    GameStateManager.MasterGameState++;
                    WMNotVisited1=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(0);



                }
         }
        
         if(target.name == "WorldMonument2")
         {
                if(WMNotVisited2){
                    GameStateManager.MasterGameState++;
                    WMNotVisited2=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(1);
                }
         }
         if(target.name == "WorldMonument3")
         {
                if(WMNotVisited3){
                    GameStateManager.MasterGameState++;
                    WMNotVisited3=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(2);
                }
         }
         if(target.name == "WorldMonument4")
         {
                if(WMNotVisited4){
                    GameStateManager.MasterGameState++;
                    WMNotVisited4=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(3);
                }
         }
         if(target.name == "WorldMonument5")
         {
                if(WMNotVisited5){
                    GameStateManager.MasterGameState++;
                    WMNotVisited5=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(4);
                }
         }
         if(target.name == "WorldMonument6")
         {
                if(WMNotVisited6){
                    GameStateManager.MasterGameState++;
                    WMNotVisited6=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(5);
                }
         }
                 if(target.name == "WorldMonument7"){
         
                if(WMNotVisited7){
                    GameStateManager.MasterGameState++;
                    WMNotVisited7=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(6);
                }
         }

        }
        */  
     
     
  
}
