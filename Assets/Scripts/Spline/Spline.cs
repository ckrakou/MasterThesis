﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Spline : MonoBehaviour
{
    public bool Debugging;

    public List<Catmul> Segments;
    public GameObject Vehicle;
    public float TraversalTime;
    [Tooltip("How many points each segment should be split into. More points means more precision in traversal.")]
    public int Resolution = 10;
    public float Delay = 0;
    public Transform FacingPoint;

    private float startTime;
    private Vector3 facingOffset;
    private List<Vector3> points;
    private bool isTraveling;
    private int currentSpline;
    private float TraversalTimePerSegment;
    private Transform manager;


    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        facingOffset = FacingPoint.transform.position;
        manager = transform.root;
        points = new List<Vector3>();
        TraversalTimePerSegment = TraversalTime / Segments.Count;

        foreach (var segment in Segments)
        {
            segment.amountOfPoints = Resolution;
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
        if (isTraveling && t >= 1)
        {
            if (currentSpline == Segments.Count - 1)
            {
                StopTravelling();
            }
            else
            {
                t = 0;
                currentSpline += 1;
            }
        }

        if (isTraveling && t < 1)
        {
            t += Time.deltaTime/TraversalTimePerSegment ;

            Vector3 newpos = Segments[currentSpline].GetPos(t);

            if (Debugging)
                Debug.Log(GetType() + ": Aquired position for segment " + currentSpline + ", coordinates: " + newpos);




            //FacingPoint.position += facingOffset;
            FacingPoint.position = transform.position + facingOffset;
            Vehicle.transform.LookAt(FacingPoint);

                

            Vehicle.transform.position = newpos;

        }
    }

    private void StopTravelling()
    {
        /*
        Vehicle.GetComponent<CharacterController>().enabled = true;
        Vehicle.GetComponent<FirstPersonController>().enabled = true;
        */

        isTraveling = false;
        Vehicle = null;
        this.transform.position = Vector3.zero;
        this.transform.SetParent(manager);

    }

    public void StartTravelling(GameObject vehicle)
    {
        StartCoroutine(Travel(vehicle));
    }

        public IEnumerator Travel(GameObject vehicle)
    {
        if (Debugging)
            Debug.Log(this.GetType() + ": travel started, moving "+vehicle.name);

        this.Vehicle = vehicle;
        transform.SetParent(null);
        transform.position = vehicle.transform.position;

        vehicle.GetComponent<CharacterController>().enabled = false;
        vehicle.GetComponent<FirstPersonController>().enabled = false;

        yield return new WaitForSeconds(Delay);

        //FacingPoint = new GameObject("point").transform;
        FacingPoint.position = Vehicle.transform.position;
        isTraveling = true;
        currentSpline = 0;
        t = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(FacingPoint.transform.position,3);
    }
}
