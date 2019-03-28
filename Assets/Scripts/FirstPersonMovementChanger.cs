using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using DG.Tweening;


public class FirstPersonMovementChanger : MonoBehaviour
{
    public bool Debugging;

    [Header("Movement Speed")]
    public float WalkSpeedNoiseInterval = 1f;
    public float WalkSpeedNoiseStandardDeviation = 1f;
    public float WalkSpeedNoiseMaxDeviation = 5f;
   

    private FirstPersonController controller;
    private NormalDist normal;

    private float nextWalkSpeedNoise;
    private float nextPositionNoise;
    private float walkSpeedMean;
    private float initialMouselookClamp;
    private float initialYSensitivity;

    private bool walkSpeedNoise = false;
    private bool PositionNoise = false;
    private bool mouseLookLocked = false;


    // Start is called before the first frame update
    void Start()
    {
        normal = GetComponent<NormalDist>();
        controller = GetComponent<FirstPersonController>();

        nextWalkSpeedNoise = Time.time + WalkSpeedNoiseInterval;
        walkSpeedMean = controller.m_WalkSpeed;
        initialMouselookClamp = controller.m_MouseLook.MaximumX;
        initialYSensitivity = controller.m_MouseLook.YSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Debugging)
        {
            if (Input.GetKey(KeyCode.P))
            {
                ToogleSpeedNoise();
            }
            if (Input.GetKey(KeyCode.M))
            {
                ToggleMoveNoise();
            }
            if (Input.GetKey(KeyCode.N))
            {
                ToggleMovementType();
            }
        }

        if (walkSpeedNoise && Time.time > nextWalkSpeedNoise)
        {
            ToggleMovementType();

        }


        
    }

    public void ToggleMoveNoise()
    {
        PositionNoise = !PositionNoise;
        if (Debugging)
        {
            Debug.Log(this.GetType() + ": Toggling Movement Noise");
        }
    }

    public void ToogleSpeedNoise()
    {
        walkSpeedNoise = !walkSpeedNoise;
        /*
        if (walkSpeedNoise)
        {
            controller.m_WalkSpeed = walkSpeedMean;
        }
        */
        if (Debugging)
        {
            Debug.Log(this.GetType() + ": Toggling Speed Noise");
        }


    }

    public void ToggleMovementType()
    {
        if (Debugging)
        {
            Debug.Log(this.GetType() + ": Toggling Mouse Look");
        }
        if (mouseLookLocked)
        {
            controller.m_MouseLook.YSensitivity = initialYSensitivity;
            controller.m_MouseLook.MinimumX = -initialMouselookClamp;
            controller.m_MouseLook.MaximumX = initialMouselookClamp;

        }
        else
        {
            controller.m_MouseLook.YSensitivity = 0;
            controller.m_MouseLook.MinimumX = 0;
            controller.m_MouseLook.MaximumX = 0;
        }

        mouseLookLocked = !mouseLookLocked;
    }

    private void ChangeWalkSpeed()
    {
        float target = normal.StandardNormalDistribution(walkSpeedMean, WalkSpeedNoiseStandardDeviation, walkSpeedMean - WalkSpeedNoiseMaxDeviation, walkSpeedMean + WalkSpeedNoiseMaxDeviation);

            DOTween.To(() => controller.m_WalkSpeed, x => controller.m_WalkSpeed = x, target, WalkSpeedNoiseInterval / 2);


        nextWalkSpeedNoise = Time.time + WalkSpeedNoiseInterval;

        if (Debugging)
        {
            Debug.Log(this.GetType() + ": time is " + Time.time);
            Debug.Log(this.GetType() + ": Changing walk speed to " + target);
            Debug.Log(this.GetType() + ": Next change at " + nextWalkSpeedNoise);
        }
    }

    
}



