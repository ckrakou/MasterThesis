using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
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
        GameObject obj = Instantiate(SpawnOnDeath, Player.transform.position, Player.transform.rotation);
        obj.transform.localScale = Scale;
    }

    public void GoBackToStartScene()
    {
        StartCoroutine(SceneChanger());
    }

    private IEnumerator SceneChanger()
    {
        yield return new WaitForSeconds(TimeBeforeFade);
        fadeTimestamp = Time.time;
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(FadeTime);
        SceneManager.LoadScene(SceneName);
    }

    private IEnumerator FadeOut()
    {
        initialSkyboxExposure = RenderSettings.skybox.GetFloat("_Exposure");
        skyboxExposureInterval = EndValue - initialSkyboxExposure;


        float t = 0;
        while (t < 1)
        {
            RenderSettings.skybox.SetFloat("_Exposure", Mathf.Lerp(initialSkyboxExposure,EndValue,t));

            t += Time.deltaTime / FadeTime;
            yield return null;
        }

    }
}
