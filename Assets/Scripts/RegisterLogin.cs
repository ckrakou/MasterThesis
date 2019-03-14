﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegisterLogin : MonoBehaviour
{
    private const string V = "playtime: ";
    public GameObject Player;

	private float playtime;

	void Start(){
		//RegisterSucessfullLogin();
		//Debug.Log("registration started");
	//RegisterPlayerDeath();
}
void Update(){
	playtime = playtime+Time.deltaTime;

}
	public void RegisterSucessfullLogin(){
		StartCoroutine(RegisterPlayerLogin());

	} 
	
    IEnumerator RegisterPlayerLogin(){
        //create webform
        WWWForm registerForm = new WWWForm();
        registerForm.AddField("is_player_logged_in", "yes");

        //call php script
      //  WWW www = new WWW("http://hawaiipizza.dk/stuff/registerlogin.php", registerForm);


 using (UnityWebRequest www = UnityWebRequest.Post("http://hawaiipizza.dk/stuff/registerlogin.php", registerForm))
        {
            yield return www.SendWebRequest();

            Debug.Log(www.downloadHandler.text);

         if(www.downloadHandler.text=="0: Sucess!"){
            Debug.Log("logintime sucessfully stored in database");	
           
        }    
        }    
    }
    IEnumerator RegisterPlayerDeath(){
        //create webform
        WWWForm DeathForm = new WWWForm();
        DeathForm.AddField("x", Player.transform.position.x.ToString());
		DeathForm.AddField("y", Player.transform.position.y.ToString());
		DeathForm.AddField("z", Player.transform.position.y.ToString());
		DeathForm.AddField("plytime", playtime.ToString());


        //call php script
      //  WWW www = new WWW("http://hawaiipizza.dk/stuff/registerlogin.php", registerForm);


 using (UnityWebRequest www = UnityWebRequest.Post("http://hawaiipizza.dk/stuff/registerlogin.php", DeathForm))
        {
            yield return www.SendWebRequest();

            Debug.Log(www.downloadHandler.text);

         if(www.downloadHandler.text=="0: Sucess!"){
            Debug.Log("Deathcoordinates sucessfully stored in database");	
           
        }    
        }    
    }


}
