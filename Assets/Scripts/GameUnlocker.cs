using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUnlocker : MonoBehaviour
{
    public string SceneToLoad;


    private void Start()
    {

        if (GetComponent<IdentityTester>().KeyFound)
        {
            GetComponent<FileUpload>().Button.SetActive(false);
            GetComponent<FileUpload>().Text.SetActive(true);
            GetComponent<FileUpload>().enabled = false;
        }
    }

    public void UnlockMainScene()
    {
        IdentityTester id = GetComponent<IdentityTester>();
        PlayerPrefs.SetString(id.Key, id.IdentityString);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneToLoad);
    }
}
