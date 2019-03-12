using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateCollider : MonoBehaviour
{
    public GameObject GameControl;
    public GameObject UI;
  

    private bool WMNotVisited1=true,WMNotVisited2=true,WMNotVisited3=true,WMNotVisited4=true,WMNotVisited5=true,WMNotVisited6=true,WMNotVisited7=true;
  
    
    void OnTriggerEnter(Collider target)
     {
         if(target.name == "WorldMonument1(Clone)")
         {
                if(WMNotVisited1){
                    GameStateManager.MasterGameState++;
                    WMNotVisited1=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(0);
                }
         }
        
         if(target.name == "WorldMonument2(Clone)")
         {
                if(WMNotVisited2){
                    GameStateManager.MasterGameState++;
                    WMNotVisited2=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(1);
                }
         }
         if(target.name == "WorldMonument3(Clone)")
         {
                if(WMNotVisited3){
                    GameStateManager.MasterGameState++;
                    WMNotVisited3=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(2);
                }
         }
         if(target.name == "WorldMonument4(Clone)")
         {
                if(WMNotVisited4){
                    GameStateManager.MasterGameState++;
                    WMNotVisited4=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(3);
                }
         }
         if(target.name == "WorldMonument5(Clone)")
         {
                if(WMNotVisited5){
                    GameStateManager.MasterGameState++;
                    WMNotVisited5=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(4);
                }
         }
         if(target.name == "WorldMonument6(Clone)")
         {
                if(WMNotVisited6){
                    GameStateManager.MasterGameState++;
                    WMNotVisited6=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(5);
                }
                 if(target.name == "WorldMonument7(Clone)")
         {
                if(WMNotVisited7){
                    GameStateManager.MasterGameState++;
                    WMNotVisited7=false;
                    GameControl.GetComponent<GameStateController>().TriggerWorldEvents(GameStateManager.MasterGameState);
                    UI.GetComponent<UI>().ChangeSign(6);
                }
         }
         }
     }
}
