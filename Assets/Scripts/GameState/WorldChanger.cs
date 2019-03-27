using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(WorldTimer))]
public class WorldChanger : MonoBehaviour
{
    [Header("Skybox")]
    public LinearChange SkyboxMode = LinearChange.NONE;
    [Range(0,1)]
    public float MinimumSkyboxExposure = 0.6f;
    [Range(0, 1)]
    public float MaximumSkyboxExposure = 0.8f;

    private float skyboxExposureInterval;

    // Start is called before the first frame update
    void Start()
    {
        skyboxExposureInterval = MaximumSkyboxExposure - MinimumSkyboxExposure;
        SetSyboxExposure(MinimumSkyboxExposure);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSyboxExposure(float progression)
    {
        switch (SkyboxMode)
        {
            case LinearChange.INCREASE:
                RenderSettings.skybox.SetFloat("_Exposure", MinimumSkyboxExposure + (progression * skyboxExposureInterval));
                break;
            case LinearChange.DECREASE:
                RenderSettings.skybox.SetFloat("_Exposure", MaximumSkyboxExposure - (progression * skyboxExposureInterval));
                break;
            case LinearChange.NONE:
                break;
            default:
                break;
        }
    }

    public enum LinearChange
    {
        INCREASE, DECREASE, NONE
    }

}

