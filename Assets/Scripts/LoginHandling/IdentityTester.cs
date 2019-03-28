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
    public GameObject Button;

    public string[] RejectionMessages;
    public GameObject RejectionText;

    private string foundString;

    // Start is called before the first frame update
    void Awake()
    {

        foundString = PlayerPrefs.GetString(Key);

        if (Debugging)
            Debug.Log(GetType() + ": found string " + foundString);

        if (foundString == IdentityString)
        {
            Button.SetActive(false);
            RejectionText.SetActive(true);
            RejectionText.GetComponentInChildren<Text>().text = RejectionMessages[UnityEngine.Random.Range((int)0, RejectionMessages.Length - 1)];
            GetComponent<SQLDatabaseConnection>().RegisterFailedLogin();

        }
        else
        {
            RejectionText.SetActive(false);
            Button.SetActive(true);
        }
    }

    public void WriteToPrefs()
    {
        if (Debugging)
            Debug.Log(GetType() + ": writing " + IdentityString + " to " + Key);

        PlayerPrefs.SetString(Key, IdentityString);
    }

   


}
