using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentityTester : MonoBehaviour
{
    public bool Debugging;

    public string Key;
    public string IdentityString;
    public string[] RejectionMessages;
    public GameObject RejectionText;

    [HideInInspector]
    public bool KeyFound = false;

    private string foundString;

    // Start is called before the first frame update
    void Awake()
    {

        if (PlayerPrefs.HasKey(Key) && PlayerPrefs.GetString(Key).Equals(IdentityString))
        {
            

            if (Debugging)
            {
                Debug.Log(GetType() + ": found key "+Key);
                PlayerPrefs.DeleteKey(Key);
            }
            else
            {
                KeyFound = true;
            }

        }
        else
        {
            if (Debugging)
                Debug.Log(GetType() + ": no such key " + Key);

        }


    }




}
