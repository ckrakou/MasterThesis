using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{


    public Image[] signs;

    public Sprite[] Nothing;
    public Sprite[] WizardSigns;
   
    // Start is called before the first frame update
    void Start()
    {
        ChangeSign(0);
        ChangeSign(1);
        ChangeSign(2);
        ChangeSign(3);
        ChangeSign(4);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
//change top right UI Image
    public void ChangeSign(int SignNumber){
        
        int RandomImage = Random.Range(1,3);

        Debug.Log(RandomImage);
        switch(RandomImage) {
                case 1:
                signs[SignNumber].sprite = Nothing[SignNumber];
                break;

                case 2:
                signs[SignNumber].sprite = WizardSigns[SignNumber];
                break;
        }   

            signs[SignNumber].color = new Color32(229,3,3,137);
    StartCoroutine(Blink(SignNumber));
    }

    IEnumerator Blink(int SignNumber) {
  signs[SignNumber].color = new Color32(229,3,3,137);  
    yield return new WaitForSeconds(0.5f);       
 
   signs[SignNumber].color = new Color32(229,3,3,0);  
    yield return new WaitForSeconds(0.5f);       
 
    signs[SignNumber].color = new Color32(229,3,3,137);       
    yield return new WaitForSeconds(0.2f);

    signs[SignNumber].color = new Color32(229,3,3,0);
    yield return new WaitForSeconds(0.7f);

    signs[SignNumber].color = new Color32(229,3,3,137);
      
 }


}
