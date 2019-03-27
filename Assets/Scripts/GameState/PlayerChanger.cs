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

    // Start is called before the first frame update
    void Start()
    {
        movement = Player.GetComponent<FirstPersonMovementChanger>();
        visuals = Player.GetComponent<FirstPersonVisualChanger>();
        timer = GetComponent<WorldTimer>();

        AdjustMouseNoise(0);
        AdjustMouseSmoothness(0);
        AdjustMovementNoise(0);
        AdjustMovementSpeed(0);

        visuals.SmoothingMinimum = MouseAdjustmentChange.lower.initialValue;
        visuals.SmoothingMaximum = MouseAdjustmentChange.upper.initialValue;
        visuals.SmoothingInterval = MouseAdjustmentChange.interval.initialValue;

        visuals.ToggleNoise();
        visuals.ToggleSensitivityShift();
        visuals.ToggleSmoothChange();
        movement.ToogleSpeedNoise();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void AdjustMouseNoise(float progression)
    {
            visuals.NoiseStandardDeviation = Mathf.Lerp(MouseLookNoise.deviation.initialValue, MouseLookNoise.deviation.endValue, progression);

            visuals.NoiseInterval = Mathf.Lerp(MouseLookNoise.interval.initialValue, MouseLookNoise.interval.endValue, progression);

            visuals.NoiseBoundary = Mathf.Lerp(MouseLookNoise.bounds.initialValue, MouseLookNoise.bounds.endValue, progression);

    }
    public void AdjustMouseSmoothness(float progression)
    {
            visuals.SmoothingInterval = Mathf.Lerp(MouseAdjustmentChange.interval.initialValue, MouseAdjustmentChange.interval.endValue, progression);

            visuals.SmoothingMaximum = Mathf.Lerp(MouseAdjustmentChange.upper.initialValue, MouseAdjustmentChange.upper.endValue, progression);

            visuals.SmoothingMinimum = Mathf.Lerp(MouseAdjustmentChange.lower.initialValue, MouseAdjustmentChange.lower.endValue, progression);
    }

    public void AdjustMovementNoise(float progression)
    {

    }
    
    public void AdjustMovementSpeed(float progression)
    {
            movement.WalkSpeedNoiseInterval = Mathf.Lerp(MovementSpeed.interval.initialValue, MovementSpeed.interval.endValue, progression);

            movement.WalkSpeedNoiseMaxDeviation = Mathf.Lerp(MovementSpeed.bounds.initialValue, MovementSpeed.bounds.endValue, progression);

            movement.WalkSpeedNoiseStandardDeviation = Mathf.Lerp(MovementSpeed.deviation.initialValue, MovementSpeed.deviation.endValue, progression);
    }
    
}

[System.Serializable]
public struct GaussianVariableChange
{
    public VariableChange mean;
    public VariableChange deviation;
    public VariableChange interval;
    public VariableChange bounds;
}

[System.Serializable]
public struct IntervalVariableChange
{
    public VariableChange upper;
    public VariableChange lower;
    public VariableChange interval;
}

[System.Serializable]
public struct VariableChange
{
    public float initialValue;
    public float endValue;
    public float delayInMinutes;
}