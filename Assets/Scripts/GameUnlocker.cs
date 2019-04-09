using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUnlocker : MonoBehaviour
{
    public bool Debugging;
    public float FadeTime = 0.5f;
    public string SceneToLoad;

    private Fader fader;
    private IdentityTester idTest;

    private void Start()
    {
        fader = GetComponent<Fader>();
        fader.FadeTime = FadeTime;

        idTest = GetComponent<IdentityTester>();


        if(idTest.KeyFound)
            fader.FadeIn();

        if (GetComponent<IdentityTester>().KeyFound)
        {
            if (Debugging)
                Debug.Log(GetType() + ": Key found, disabling button");

            GetComponent<FileUpload>().Button.SetActive(false);
            //GetComponent<FileUpload>().WelcomeText.SetActive(true);
            GetComponent<FileUpload>().enabled = false;
        }
    }

    public void UnlockMainScene()
    {

        if (GetComponent<IdentityTester>().KeyFound == false)
        {
            StartCoroutine(UnlockThread());
        }
        else
        {
            if (Debugging)
                Debug.Log(GetType() + ": Key found, not loading");
        }
    }

    private IEnumerator UnlockThread()
    {
        fader.FadeOut();
        yield return new WaitForSeconds(FadeTime);

        PlayerPrefs.SetString(idTest.Key, idTest.IdentityString);
        PlayerPrefs.Save();
        GetComponent<SQLDatabaseConnection>().RegisterSucessfullLogin();
        SceneManager.LoadScene(SceneToLoad);
    }
}
