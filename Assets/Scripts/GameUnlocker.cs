using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUnlocker : MonoBehaviour
{
    public bool Debugging;

    public string SceneToLoad;


    private void Start()
    {

        if (GetComponent<IdentityTester>().KeyFound)
        {
            if (Debugging)
                Debug.Log(GetType() + ": Key found, disabling button");

            GetComponent<FileUpload>().Button.SetActive(false);
            GetComponent<FileUpload>().Text.SetActive(true);
            GetComponent<FileUpload>().enabled = false;
        }
    }

    public void UnlockMainScene()
    {

        if (GetComponent<IdentityTester>().KeyFound == false)
        {
            IdentityTester id = GetComponent<IdentityTester>();
            PlayerPrefs.SetString(id.Key, id.IdentityString);
            PlayerPrefs.Save();
            GetComponent<SQLDatabaseConnection>().RegisterSucessfullLogin();
            SceneManager.LoadScene(SceneToLoad);
        }
        else
        {
            if (Debugging)
                Debug.Log(GetType() + ": Key found, not loading");
        }
    }
}
