using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class IdentityTester : MonoBehaviour
{
    public bool Debugging;

    public string Key;
    public string IdentityString;
    public string[] RejectionMessages;
    //public Text ResponseText;

    //[HideInInspector]
    public bool KeyFound = false;

    private string foundString;

    // Start is called before the first frame update
    void Awake()
    {

        if (PlayerPrefs.HasKey(Key) && PlayerPrefs.GetString(Key).Equals(IdentityString))
        {
            KeyFound = true;

            if (Debugging)
                Debug.Log(GetType() + ": found key " + Key);

            //ResponseText.SetActive(true);
            //ResponseText.text = RejectionMessages[UnityEngine.Random.Range((int)0, RejectionMessages.Length - 1)];


        }
        else
        {
            if (Debugging)
                Debug.Log(GetType() + ": no such key " + Key);

        }


    }




}
