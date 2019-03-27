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

    [Header("Movement Speed Shift")]
    public GaussianVariableChange MovementSpeed;

    private FirstPersonMovementChanger movement;
    private FirstPersonVisualChanger visuals;
    private WorldTimer timer;
    private bool noise;

    // Start is called before the first frame update

    void Start()
    {
        movement = Player.GetComponent<FirstPersonMovementChanger>();
        visuals = Player.GetComponent<FirstPersonVisualChanger>();
        timer = GetComponent<WorldTimer>();
        
        AdjustMouseNoise(0);
        AdjustMouseSmoothness(0);
        AdjustMovementSpeed(0);

        StartNoise();

    }

    public void StartNoise()
    {
        noise = true;
        movement.ToogleSpeedNoise();
        visuals.ToggleNoise();
        visuals.ToggleSmoothChange();
    }

    public void StopNoise()
    {
        noise = false;
        movement.ToogleSpeedNoise();
        visuals.ToggleNoise();
        visuals.ToggleSmoothChange();
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

    public void AdjustMovementSpeed(float progression)
    {
        if (noise)
        {
            movement.WalkSpeedNoiseStandardDeviation = Mathf.Lerp(0, MovementSpeed.deviation,progression);
            movement.WalkSpeedNoiseMaxDeviation = Mathf.Lerp(0, MovementSpeed.bounds, progression);
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