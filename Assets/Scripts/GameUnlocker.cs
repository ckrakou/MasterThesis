using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUnlocker : MonoBehaviour
{
    public bool Debugging;
    public string SceneToLoad;

    private Fader fader;
    private IdentityTester idTest;

    private void Start()
    {

        idTest = GetComponent<IdentityTester>();
        fader = GetComponent<Fader>();

        if (idTest.KeyFound)
        {

            

            fader.FadeInKeyFound(idTest.RejectionMessages[Random.Range(0,idTest.RejectionMessages.Length - 1)]);
        }
        else
        {
            fader.FadeInPlayable();

        }
        
    }

    public void UnlockMainScene()
    {
        // Double-check in case of external calls
        if(idTest.KeyFound == false)
            StartCoroutine(UnlockThread());
    }

    private IEnumerator UnlockThread()
    {
        fader.FadeOut();
        yield return new WaitForSeconds(fader.FadeTime * 2);

        PlayerPrefs.SetString(idTest.Key, idTest.IdentityString);
        PlayerPrefs.Save();
        GetComponent<SQLDatabaseConnection>().RegisterSucessfullLogin();
        SceneManager.LoadScene(SceneToLoad);
    }
}
