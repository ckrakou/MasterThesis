using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;
using DG.Tweening;
public class FirstPersonVisualChanger : MonoBehaviour
{
    public bool Debugging;

    [Header("Mouse Smoothing Paramenters")]
    public float SmoothingMinimum = 1;
    public float SmoothingMaximum = 15;
    public float SmoothingInterval = 1.0f;

    [Header("Mouse Sensitivity Parameters")]
    public float MouseSensitivityMinimum = 1;
    public float MouseSensitivityMaximum = 3;

    [Header("Mouse Noise Parameters")]
    public float NoiseInterval = 1;
    public float NoiseStandardDeviation = 0.2f;
    public float NoiseBoundary = 1f;

    private FirstPersonController controller;
    private bool lookNoise;
    private bool sensitivityShift;
    private bool smoothChange;
    private float smoothChangeTimestamp;
    private float noiseChangeTimestamp;
    private float initialSensitivityX;
    private float initialSensitivityY;
    private NormalDist normal;

    void Start()
    {
        controller = GetComponent<FirstPersonController>();
        normal = GetComponent<NormalDist>();
        smoothChangeTimestamp = Time.time;
        noiseChangeTimestamp = Time.time;
        initialSensitivityX = controller.m_MouseLook.XSensitivity;
        initialSensitivityY = controller.m_MouseLook.YSensitivity;

        

        // needs to be smooth for noise to work
        controller.m_MouseLook.smooth = true;

        if (Debugging)
        {
            Debug.Log(this.GetType() + ": Initialised. Left Control = Invert mouse look. Left Alt = Noise on mouse look. Return = change in mouse smoothing. Insert = shift in sensitivity");
        }
    }

    void Update()
    {
        if (Debugging)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                InvertControls();
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                ToggleNoise();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ToggleSmoothChange();
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                ToggleSensitivityShift();
            }
        }

        if (lookNoise&& Time.time >noiseChangeTimestamp)
        {
            this.transform.Rotate(new Vector3(0, normal.StandardNormalDistribution(0, NoiseStandardDeviation, -NoiseBoundary, NoiseBoundary), 0));
            this.transform.Find("FirstPersonCharacter").Rotate(new Vector3(normal.StandardNormalDistribution(0, NoiseStandardDeviation, -NoiseBoundary, NoiseBoundary), 0, 0));
            noiseChangeTimestamp += NoiseInterval * normal.StandardNormalDistribution(NoiseInterval/2,1,0,1);
        }

        if (sensitivityShift)
            ShiftMouseSensitivity();

        if (smoothChange && smoothChangeTimestamp + SmoothingInterval < Time.time)
        {
            ChangeSmoothness();
        }

    }

    private void ChangeSmoothness()
    {
        float newSmoothTime = Random.Range(SmoothingMinimum, SmoothingMaximum);
        controller.m_MouseLook.smoothTime = newSmoothTime;
        smoothChangeTimestamp = Time.time + SmoothingInterval;

        if (Debugging)
        {
            Debug.Log(this.GetType() + ": time is " + Time.time);
            Debug.Log(this.GetType() + ": Changing smoothness to " + newSmoothTime);
            Debug.Log(this.GetType() + ": Next change at " + Time.time + SmoothingInterval);
        }
    }

    public void InvertControls()
    {
        controller.m_MouseLook.XSensitivity = controller.m_MouseLook.XSensitivity * -1;
        controller.m_MouseLook.YSensitivity = controller.m_MouseLook.YSensitivity * -1;
        if (Debugging)

            Debug.Log(this.GetType() + ": Inverting Controls");

    }

    public void ToggleNoise()
    {
        lookNoise = !lookNoise;
        if (Debugging)
            Debug.Log(this.GetType() + ": Toggling Noise");

    }

    public void ToggleSmoothChange()
    {
        smoothChange = !smoothChange;
        smoothChangeTimestamp = Time.time;

        if (Debugging)
        {
            Debug.Log(this.GetType() + ": Toggling Smoothness");
            Debug.Log(this.GetType() + ": time is " + Time.time);
            Debug.Log(this.GetType() + ": Next change at " + smoothChangeTimestamp + SmoothingInterval);
        }
    }

    public void ToggleSensitivityShift()
    {
        Debug.Log(this.GetType() + ": Toggling Mouse Sensitivity");
        if (sensitivityShift == true)
        {
            controller.m_MouseLook.XSensitivity = initialSensitivityX;
            controller.m_MouseLook.YSensitivity = initialSensitivityY;
            Debug.Log(this.GetType() + ": Reset Mouse Sensitivity to " + initialSensitivityX + ", " + initialSensitivityY);
        }

        sensitivityShift = !sensitivityShift;
    }

    private void ShiftMouseSensitivity()
    {

        controller.m_MouseLook.XSensitivity = normal.StandardNormalDistribution(initialSensitivityX, 1, MouseSensitivityMinimum, MouseSensitivityMaximum);
        controller.m_MouseLook.YSensitivity = normal.StandardNormalDistribution(initialSensitivityY, 1, MouseSensitivityMinimum, MouseSensitivityMaximum);

    }

   

}
