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


        if (idTest.KeyFound)
        {



            if (Debugging)
                Debug.Log(GetType() + ": " + idTest.RejectionMessages[Random.Range((int)0, idTest.RejectionMessages.Length - 1)]);

            fader.FadeResponse(idTest.RejectionMessages[Random.Range((int)0, idTest.RejectionMessages.Length - 1)]);
        }
        else
        {
            //fader.FadeInText();
            fader.FadeIn();

        }
        /*
        if (GetComponent<IdentityTester>().KeyFound)
        {
            if (Debugging)
                Debug.Log(GetType() + ": Key found, disabling button");


            GetComponent<FileUpload>().Button.GetComponent<Button>().interactable = false;
            //GetComponent<FileUpload>().WelcomeText.SetActive(true);
            GetComponent<FileUpload>().enabled = false;
        }
        */
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
        fader.FadeOutText();
        yield return new WaitForSeconds(FadeTime);

        PlayerPrefs.SetString(idTest.Key, idTest.IdentityString);
        PlayerPrefs.Save();
        GetComponent<SQLDatabaseConnection>().RegisterSucessfullLogin();
        SceneManager.LoadScene(SceneToLoad);
    }
}
