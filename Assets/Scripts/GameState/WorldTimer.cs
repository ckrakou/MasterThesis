using System;
using UnityEngine;
using UnityEngine.Events;

// Magic Code (TM) allows for float arguments in events
[System.Serializable] public class UnityEventFloat : UnityEvent<float> { }

[System.Serializable]
public struct TimedEvent{
    public int Time;
    public UnityEvent Function;

    [HideInInspector]
    public bool HasHappened;
}
public class WorldTimer : MonoBehaviour
{
    public bool Debugging;

    [Tooltip("Total Play Time in Minutes")]
    [Range(0,30)]
    public float PlayTime = 20;
    [HideInInspector]
    public float CurrentProgression = 0;

    public UnityEventFloat ProgressEvents;
    public UnityEvent EndGameEvents;
    public TimedEvent[] TimedEvents;

    private float decayRate = 1f;
    private float savedRate = 1f;
    private float timeProgressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Debugging)
            Debug.Log(GetType() + ": Time Begins");
    }

    
    // Update is called once per frame
    void Update()
    {
        if (timeProgressed > PlayTime * 60)
        {
            EndGame();
            GetComponent<WorldTimer>().enabled = false;
        }
        else
        {
            timeProgressed += decayRate * Time.deltaTime;
            CurrentProgression = timeProgressed / PlayTime;
            ProgressEvents.Invoke(CurrentProgression);
            TriggerTimedEvents();

        }
    }

    public void StopTimeFor(int seconds)
    {
        
        savedRate = decayRate;
        decayRate = 0;
        Invoke("StartTime", seconds);

        if (Debugging)
        {
            Debug.Log(GetType() + ": Stopping time for " + seconds + " seconds");
        }
    }

    private void StartTime()
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

        if (Debugging)
        {
            Debug.Log(GetType() + ": Game Completed at " + Time.time);
        }
    }

    private void TriggerTimedEvents()
    {
        for (int i = 0; i < TimedEvents.Length; i++)
        {
            var currentEvent = TimedEvents[i];

            if (currentEvent.Time/PlayTime > CurrentProgression && currentEvent.HasHappened == false)
            {
                currentEvent.HasHappened = true;
                currentEvent.Function.Invoke();
            }
        }
    }


}
