 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using UnityEngine;
 
 public class SplashUIController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
     private Text myText;
 
     void Start (){
         myText = GetComponentInChildren<Text>();
     }
 
     public void OnPointerEnter (PointerEventData eventData)
     {
         myText.text = "Hovering";
     }
 
     public void OnPointerExit (PointerEventData eventData)
     {
         myText.text = "Not Hovering";
     }
 }