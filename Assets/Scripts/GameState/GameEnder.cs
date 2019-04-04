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
    public float EndValue;
     

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

        yield return new WaitForSeconds(TimeBeforeFade);
        fadeTimestamp = Time.time;
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(FadeTime);
        SceneManager.LoadScene(SceneName);
    }

    private IEnumerator FadeOut()
    {
        if (Debugging)
            Debug.Log(GetType() + ": Starting Fadeout, duration: "+FadeTime);

        initialSkyboxExposure = RenderSettings.skybox.GetFloat("_Exposure");
        float startTimeStamp = Time.time;
        float fadeTimestamp = Time.time + FadeTime;

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

    }
}
