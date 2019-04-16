using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Magic Code (TM) allows for float arguments in events
[System.Serializable] public class UnityEventFloat : UnityEvent<float> { }


public class WorldTimer : MonoBehaviour
{
    public bool Debugging;

    [Tooltip("Total Play Time in Minutes")]
    [Range(1, 30)]
    public float PlayTime = 20;
    [HideInInspector]
    public float CurrentProgression = 0;

    public UnityEventFloat ProgressEvents;
    public UnityEvent EndGameEvents;
    public List<TimedEvent> TimedEvents;

    private float decayRate = 1f;
    private float savedRate = 1f;
    private float timeProgressed = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Oh, is this not what you expected? Nevermind. We're going to have so much fun here");
        if (Debugging)
        {
            Debug.Log(GetType() + ": Time Begins. 10 times normal speed");
            decayRate = 10f;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (timeProgressed > PlayTime * 60)
        {
            EndGame();
        }
        else
        {
            timeProgressed += decayRate * Time.deltaTime;
            CurrentProgression = timeProgressed / (PlayTime * 60);
            TriggerTimedEvents();


            ProgressEvents.Invoke(CurrentProgression);


        }

        if (Debugging)
            Debug.Log(GetType() + ": time is " + timeProgressed);
    }

    public void StopTime()
    {

        savedRate = decayRate;
        decayRate = 0;


        if (Debugging)
        {
            Debug.Log(GetType() + ": Stopping time");
        }
    }

    public void StartTime()
    {
        decayRate = savedRate;

        if (Debugging)
        {
            Debug.Log(GetType() + ": Starting time with rate:" + decayRate);
        }
    }

    public void AdjustCountdownRate(float percentage)
    {
        float factor = percentage / 100f;
        if (-1f > factor || factor > 1f)
        {
            throw new System.Exception(GetType() + " - AdjustCountdownRate() : percentage not between -100 and 100");
        }
        else
        {
            if (Debugging)
                Debug.Log(GetType() + ": Adjusting countdown rate from by " + (decayRate * factor));

            decayRate += decayRate * factor;

            if (Debugging)
                Debug.Log(GetType() + ": New decay rate is " + decayRate);
        }
    }

    public void ChangePlayTime(float percentage)
    {
        float factor = percentage / 100f;
        if (-1f > factor || factor > 1f)
        {
            throw new System.Exception(GetType() + " - ChangePlayTime() : percentage must be between -100 and 100");
        }
        else
        {
            if (Debugging)
                Debug.Log(GetType() + ": Adjusting countdown play time by " + (PlayTime * factor));

            PlayTime += PlayTime * factor;

            if (Debugging)
                Debug.Log(GetType() + ": New play time is " + PlayTime);
        }
    }

    private void EndGame()
    {
        EndGameEvents.Invoke();
        GetComponent<PlayerChanger>().enabled = false;
        GetComponent<WorldChanger>().enabled = false;
        GetComponent<WorldTimer>().enabled = false;


        if (Debugging)
        {
            Debug.Log(GetType() + ": Game Completed at " + Time.time);
        }
    }

    private void TriggerTimedEvents()
    {
        int removeIndex = -1;
        foreach (var timed in TimedEvents )
        {
            if ((timed.Minutes * 60) + timed.Seconds < timeProgressed)
            {
                timed.Function.Invoke();
                removeIndex = TimedEvents.IndexOf(timed);
                if (Debugging)
                    Debug.Log(GetType() + ": removed item " + removeIndex + " at time " + timeProgressed + ", Item Time:" + (timed.Minutes * 60) + timed.Seconds);
            }

        }
        if (removeIndex != -1)
        TimedEvents.RemoveAt(removeIndex);
    }


}
[System.Serializable]
public struct TimedEvent
{
    public int Minutes;
    [Range(0, 60)]
    public int Seconds;
    public UnityEvent Function;

    [HideInInspector]
    public bool HasHappened;
}