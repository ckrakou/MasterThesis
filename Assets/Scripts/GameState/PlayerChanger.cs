using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(WorldTimer))]
public class PlayerChanger : MonoBehaviour
{
    public bool Debugging;
    public GameObject Player;


    [Header("Mouse Look Noise")]
    public GaussianVariableChange MouseLookNoise;

    [Header("Mouse Adjustment Noise")]
    public IntervalVariableChange MouseAdjustmentChange;



    private FirstPersonVisualChanger visuals;
    private WorldTimer timer;
    private bool noise;

    // Start is called before the first frame update

    void Start()
    {
        
        visuals = Player.GetComponent<FirstPersonVisualChanger>();
        timer = GetComponent<WorldTimer>();
        
        AdjustMouseNoise(0);
        AdjustMouseSmoothness(0);
        
        StartNoise();
        
    }

    public void StartNoise()
    {
        noise = true;
        visuals.ToggleNoise();
        visuals.ToggleSmoothChange();

    }

    public void StopNoise()
    {
        noise = false;
        visuals.ToggleNoise();
        visuals.ToggleSmoothChange();

        AdjustMouseNoise(0);
        AdjustMouseSmoothness(0);
    }

    public void AdjustMouseNoise(float progression)
    {
        if (noise)
        {
            visuals.NoiseBoundary = Mathf.Lerp(0, MouseLookNoise.bounds, progression);
            visuals.NoiseStandardDeviation = Mathf.Lerp(0, MouseLookNoise.deviation,progression);
        }
    }

    public void AdjustMouseSmoothness(float progression)
    {
        if (noise)
        {
            visuals.SmoothingMaximum = Mathf.Lerp(MouseAdjustmentChange.initial, MouseAdjustmentChange.upper, progression);
            visuals.SmoothingMinimum = Mathf.Lerp(MouseAdjustmentChange.initial, MouseAdjustmentChange.lower, progression);

        } 
    }

   
    
}


[System.Serializable]
public struct GaussianVariableChange
{
    public float mean;
    public float deviation;
    public float bounds;
}

[System.Serializable]
public struct IntervalVariableChange
{
    public float upper;
    public float lower;
    public float initial;
}