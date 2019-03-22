using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    public bool Debugging;

    public List<Catmul> Segments;
    public GameObject Vehicle;
    public float TraversalTimePerSegment = 3;

    private List<Vector3> points;
    private bool isTraveling;
    private int currentSpline;

    private float t = 0;



    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>();

        foreach (var segment in Segments)
        {
            foreach (Vector3 point in segment.GetPoints())
            {
                points.Add(point);
            }
        }

        if (Debugging)
            Debug.Log(this.GetType() + ": Points added, " + points.Count+" total");


        if (Vehicle != null)
            StartTravelling(Vehicle);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTraveling)
        {
            
        }
    }

    public void StartTravelling(GameObject vehicle)
    {
        if (Debugging)
            Debug.Log(this.GetType() + ": travel started, moving "+vehicle.name);

        this.Vehicle = vehicle;
        isTraveling = true;
    }
}
