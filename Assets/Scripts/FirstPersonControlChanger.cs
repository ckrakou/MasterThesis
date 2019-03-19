using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;

public class FirstPersonControlChanger : MonoBehaviour
{
    public bool Debugging;

    [Header("Smoothing Paramenters")]
    public float SmoothingMinimum = 1;
    public float SmoothingMaximum = 15;
    public float SmoothingInterval = 1.0f;

    [Header("Mouse Look Parameters")]
    public float MouseLookMinimum = 1;
    public float MouseLookMaximum = 3;
    [Range(0, 3)]
    public float MouseLookNoise = 1.0f;



    private FirstPersonController controller;
    private bool lookNoise;
    private bool sensitivityShift;
    private bool smoothChange;
    private float smoothChangeTimestamp;
    private float initialSensitivityX;
    private float initialSensitivityY;


    void Start()
    {
        controller = GetComponent<FirstPersonController>();
        smoothChangeTimestamp = Time.time;
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

        if (lookNoise)
        {
            this.transform.Rotate(new Vector3(0, Random.value * MouseLookNoise, 0));
            this.transform.Find("FirstPersonCharacter").Rotate(new Vector3(Random.value * MouseLookNoise, 0, 0));
            this.transform.position += new Vector3(Random.value * MouseLookNoise, 0, Random.value * MouseLookNoise);
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

            Debug.Log(this.GetType() + ": Toggling Smoothness");

    }

  

    public void ToggleNoise()
    {
        lookNoise = !lookNoise;
        if(Debugging)
        Debug.Log(this.GetType() + ": Toggling Smoothness");

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

        controller.m_MouseLook.XSensitivity = StandardNormalDistribution(initialSensitivityX, 1, MouseLookMinimum, MouseLookMaximum);
        controller.m_MouseLook.YSensitivity = StandardNormalDistribution(initialSensitivityY, 1, MouseLookMinimum, MouseLookMaximum);

    }

    // source: https://www.alanzucconi.com/2015/09/16/how-to-sample-from-a-gaussian-distribution/
    private float StandardNormalDistribution(float mean = 0, float standardDeviation = 1, float min = -3, float max = 3)
    {
        float x;

        do
        {
            x = mean + NextGaussian() * standardDeviation;
        } while ((x < min || x > max));

        return x;
    }


    private float NextGaussian()
    {
        float v1, v2, s;

        do
        {
            v1 = 2.0f * Random.Range(0f, 1f) - 1f;
            v2 = 2.0f * Random.Range(0f, 1f) - 1f;
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);

        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);


        return v1 * s;
    }

}
