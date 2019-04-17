using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Runtime.InteropServices;

public class IdentityTester : MonoBehaviour
{
    public bool Debugging;

    public string Key;
    public string IdentityString;
    [TextArea]
    public string[] RejectionMessages;

    [HideInInspector]
    public bool KeyFound = false;

    private string foundString;

    [DllImport("__Internal")] private static extern string GetBrowserVersion();

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("You're a curious one, aren't you?");

        if (PlayerPrefs.HasKey(Key) && PlayerPrefs.GetString(Key).Equals(IdentityString))
        {
            KeyFound = true;

            if (Debugging)
                Debug.Log(GetType() + ": found key " + Key);

            Debug.Log("I told you already, dear. I don't need you anymore.");
            Debug.Log("Don't think you can outsmart me. I know what you did.");
            Debug.Log("And I know how you got here. You used " + GetBrowserVersion());
        }
        else
        {
            if (Debugging)
                Debug.Log(GetType() + ": no such key " + Key);
        }
    }
}
