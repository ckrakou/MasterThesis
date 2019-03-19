using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FirstPersonControlChanger : MonoBehaviour
{
    public bool Debugging;
    [Range(0, 3)]
    public float Noise = 1.0f;
    [Header("Smoothing Paramenters")]
    public float Minimum = 1;
    public float Maximum = 15;
    /*
    [Range(4, 7)]
    public float Mean = 5f;
    [Range(2,5)]
    public float StandardDeviation = 1f;
    */
    public float SecondsBetweenChanges = 1.0f;

    private FirstPersonController controller;
    private bool noise;
    private bool smoothChange;
    private float smoothChangeTimestamp;

    void Start()
    {
        controller = GetComponent<FirstPersonController>();
        smoothChangeTimestamp = Time.time;

        if (Debugging)
        {
            Debug.Log(this.GetType() + ": time is " + Time.time);
            Debug.Log(this.GetType() + ": Next change at " + Time.time + SecondsBetweenChanges);
        }

        // needs to be smooth for noise to work
        controller.m_MouseLook.smooth = true;
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
                ToogleSmoothChange();
            }
        }

        if (noise)
        {
            this.transform.Rotate(new Vector3(0, Random.value * Noise, 0));
            this.transform.Find("FirstPersonCharacter").Rotate(new Vector3(Random.value * Noise, 0, 0));
            this.transform.position += new Vector3(Random.value * Noise, 0, Random.value * Noise);
        }

        if (smoothChange)
        {

            
            if (smoothChangeTimestamp + SecondsBetweenChanges < Time.time)
            {
                float newSmoothTime = Random.Range(Minimum, Maximum);
                controller.m_MouseLook.smoothTime = newSmoothTime;
                smoothChangeTimestamp = Time.time + SecondsBetweenChanges;

                if (Debugging)
                {
                    Debug.Log(this.GetType() + ": time is " + Time.time);
                    Debug.Log(this.GetType() + ": Changing smoothness to " + newSmoothTime);
                    Debug.Log(this.GetType() + ": Next change at " + Time.time + SecondsBetweenChanges);
                }

                /*
                float newSmoothTime = StandardNormalDistribution(Mean, StandardDeviation);
                controller.m_MouseLook.smoothTime = newSmoothTime;
                smoothChangeTimestamp = Time.time + SecondsBetweenChanges;

                if (Debugging)
                {
                    Debug.Log(this.GetType() + ": time is " + Time.time);
                    Debug.Log(this.GetType() + ": Changing smoothness to " + newSmoothTime);
                    Debug.Log(this.GetType() + ": Next change at " + Time.time + SecondsBetweenChanges);
                }
                */
            }

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
        noise = !noise;
        if(Debugging)
        Debug.Log(this.GetType() + ": Toggling Smoothness");

    }

    public void ToogleSmoothChange()
    {
        smoothChange = !smoothChange;
        smoothChangeTimestamp = Time.time;

        if (Debugging)
        {
            Debug.Log(this.GetType() + ": Toggling Smoothness");
            Debug.Log(this.GetType() + ": time is " + Time.time);

            Debug.Log(this.GetType() + ": Next change at " + smoothChangeTimestamp + SecondsBetweenChanges);
        }
    }


    // source: https://www.alanzucconi.com/2015/09/16/how-to-sample-from-a-gaussian-distribution/
    private float StandardNormalDistribution(float mean = 0, float standardDeviation = 1)
    {
        float x;

        do
        {
            x = mean + NextGaussian() * standardDeviation;
        } while ((x < 4 || x > 7));
        /*
        if (Debugging)
            Debug.Log(this.GetType() + ": NormalDistribution returned: " + x);
            */
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
        /*
        if (Debugging)
            Debug.Log(this.GetType() + ": NextGaussian returned: " + v1 * s);
*/
        return v1 * s;
    }

}
