using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldTimer : MonoBehaviour
{
    public bool Debugging;

    [Tooltip("Total Play Time in Minutes")]
    [Range(0,30)]
    public float PlayTime = 20;
    [HideInInspector]
    public float CurrentProgression = 0;

    public UnityEvent ProgressEvents;
    public UnityEvent EndGameEvents;


    private float decayRate = 1f;
    private float timeProgressed = 0;

    // Start is called before the first frame update
    void Start()
    {

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
            ProgressEvents.Invoke();
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

}
