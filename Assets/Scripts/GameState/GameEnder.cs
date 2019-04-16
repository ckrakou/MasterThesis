using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    public bool Debugging;
    [Header("Gravestone")]
    public GameObject SpawnOnDeath;
    public Vector3 Scale = new Vector3(1,1,1);
    [Header("Scene Change")]
    public string SceneName = "Splash";
    public float TimeBeforeFade = 10;
    [Header("Fade")]
    public float FadeTime = 2;
    //public float EndValue;
    public Animator Fader;

    public GameObject EndGameMusic; 

    private float fadeTimestamp;
    private float skyboxExposureInterval;
    private float initialSkyboxExposure;


    public void SpawnGravestone(GameObject Player)
    {
        if (Debugging)
            Debug.Log(GetType() + ": Spawning tree");

        GameObject obj = Instantiate(SpawnOnDeath, Player.transform.position, Player.transform.rotation);
        obj.transform.localScale = Scale;
    }

    public void GoBackToStartScene()
    {
        StartCoroutine(SceneChanger());
    }

    private IEnumerator SceneChanger()
    {
        if (Debugging)
            Debug.Log(GetType() + ": Starting end sequence, duration is " + TimeBeforeFade);
        Debug.Log("What a beautiful tree you've become. Everyone shall marvel at your form, and know what you have done");
       

        yield return new WaitForSeconds(TimeBeforeFade);
        fadeTimestamp = Time.time;
        StartCoroutine(FadeOut());

        // https://www.quotes.net/mquote/56967
        Debug.Log("Encoded Transmission: 57686174277320676f696e67206f6e3f204772656174207175657374696f6e2e20496e2074686520456173742c207468652046617220456173742c207768656e206120706572736f6e2069732073656e74656e63656420746f2064656174682c20746865792772652073656e7420746f206120706c61636520776865726520746865792063616e2774206573636170652c206e65766572206b6e6f77696e67207768656e20616e20657865637574696f6e65722077696c6c207374657020757020626568696e64207468656d20616e64206669726520612062756c6c657420696e746f20746865206261636b206f6620746865697220686561642e20497420636f756c6420626520646179732c207765656b732c206f72206576656e207965617273206166746572207468652064656174682073656e74656e636520686173206265656e2070726f6e6f756e6365642e205468697320756e6365727461696e7479206164647320616e2065787175697369746520656c656d656e74206f6620746f727475726520746f2074686520736974756174696f6e2c20646f6e277420796f75207468696e6b3f2049742773206265656e206120706c6561737572652074616c6b696e6720746f20796f752e");

        yield return new WaitForSeconds(FadeTime);
        DontDestroyOnLoad(EndGameMusic);
        SceneManager.LoadScene(SceneName);
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("Oh, what fun this has been. Did you have a good time? Are numbers important to you? I, for one, like roman numerals");


        if (Debugging)
            Debug.Log(GetType() + ": Starting Fadeout, duration: "+FadeTime);
        /*
        initialSkyboxExposure = RenderSettings.skybox.GetFloat("_Exposure");
        float startTimeStamp = Time.time;
        float fadeTimestamp = Time.time + FadeTime;
        */
        Fader.SetTrigger("FadeOut");
       yield return new WaitForSeconds(FadeTime);
        /*
        float t = 0;
        while (t < FadeTime)
        {
            float skyboxExposure = Mathf.Lerp(initialSkyboxExposure, EndValue, t / FadeTime);
            RenderSettings.skybox.SetFloat("_Exposure", skyboxExposure );

            t = t + Time.deltaTime;

            if (Debugging)
                Debug.Log(GetType() + ": fadeout, t = " + t + ", skybox value:"+skyboxExposure);

            yield return null;
        }
        */
    }
}
