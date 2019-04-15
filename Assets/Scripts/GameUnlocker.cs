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

            if (Debugging)
                Debug.Log(GetType() + ": " + idTest.RejectionMessages[Random.Range((int)0, idTest.RejectionMessages.Length - 1)]);

            fader.FadeInKeyFound(idTest.RejectionMessages[Random.Range(0,idTest.RejectionMessages.Length - 1)]);
        }
        else
        {
            fader.FadeInPlayable();

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
        yield return new WaitForSeconds(fader.FadeTime);

        PlayerPrefs.SetString(idTest.Key, idTest.IdentityString);
        PlayerPrefs.Save();
        GetComponent<SQLDatabaseConnection>().RegisterSucessfullLogin();
        SceneManager.LoadScene(SceneToLoad);
    }
}
