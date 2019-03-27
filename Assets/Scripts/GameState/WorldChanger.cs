using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(WorldTimer))]
public class WorldChanger : MonoBehaviour
{



    private WorldTimer worldTimer;

    // Start is called before the first frame update
    void Start()
    {
        worldTimer = GetComponent<WorldTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
