 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using UnityEngine;
 
 public class SplashUIController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
     private Text myText;
     private Color textColor;
 
     void Start (){
         myText = GetComponentInChildren<Text>();
         textColor = myText.color;
     }
 
     public void OnPointerEnter (PointerEventData eventData)
     {
         myText.color=new Color32(150,60,60,255);
     }
 
     public void OnPointerExit (PointerEventData eventData)
     {
         myText.color = textColor;
     }
 }